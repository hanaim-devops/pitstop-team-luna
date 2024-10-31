namespace Pitstop.CustomerSupportService.Repositories;

public class SqlServerCustomerSupportRepository : ICustomerSupportRepository
{
    private string _connectionString;

    public SqlServerCustomerSupportRepository(string connectionString)
    {
        _connectionString = connectionString;

        // init db
        Log.Information("Initialize Database");

        Policy
        .Handle<Exception>()
        .WaitAndRetryAsync(10, r => TimeSpan.FromSeconds(10), (ex, ts) => { Log.Error(ex, "Error connecting to DB. Retrying in 10 sec"); })
        .ExecuteAsync(InitializeDBAsync)
        .Wait();
    }

    public async Task RegisterRejectionAsync(Rejection rejection)
    {
        await using var conn = new SqlConnection(_connectionString);
        const string sql = "insert into Rejection(RepairOrderId, RejectReason, RejectedAt) " +
                           "values(@RepairOrderId, @RejectReason, @RejectedAt);";
        await conn.ExecuteAsync(sql, rejection);
    }

    private async Task InitializeDBAsync()
    {
        await using (var conn = new SqlConnection(_connectionString.Replace("CustomerSupport", "master")))
        {
            await conn.OpenAsync();

            // create database
            const string sql = "IF NOT EXISTS(SELECT * FROM master.sys.databases WHERE name='CustomerSupport') CREATE DATABASE CustomerSupport;";

            await conn.ExecuteAsync(sql);
        }

        // create tables
        await using (var conn = new SqlConnection(_connectionString))
        {
            await conn.OpenAsync();

            // create tables
            const string sql = "IF OBJECT_ID('Rejection') IS NULL " +
                               "CREATE TABLE Rejection (" +
                               "  RepairOrderId varchar(50) NOT NULL," +
                               "  RejectReason varchar(255) NOT NULL," +
                               "  RejectedAt varchar(50) NOT NULL," +
                               "  PRIMARY KEY(RepairOrderId));";

            await conn.ExecuteAsync(sql);
        }
    }
}