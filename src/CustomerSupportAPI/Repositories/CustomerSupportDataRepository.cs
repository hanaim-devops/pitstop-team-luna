using System.Runtime.ExceptionServices;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Pitstop.CustomerSupportAPI.Repositories;

public class CustomerSupportDataRepository : ICustomerSupportDataRepository
{
    private readonly string _connectionString;
    
    public CustomerSupportDataRepository(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    public async Task<IEnumerable<Rejection>> GetRejectionsAsync()
    {
        await using var conn = new SqlConnection(_connectionString);
        try
        {
            var result = (await conn.QueryAsync<Rejection>("select * from Rejection")).ToArray();

            return result.Length == 0 
                ? [new Rejection(Guid.NewGuid(), "Test", DateTime.Now)] 
                : result;
        }
        catch (SqlException ex)
        {
            HandleSqlException(ex);
        }
        
        return Array.Empty<Rejection>();
    }
    
    private static void HandleSqlException(SqlException ex)
    {
        // rethrow original exception without poluting the stacktrace
        ExceptionDispatchInfo.Capture(ex).Throw();
    }
}