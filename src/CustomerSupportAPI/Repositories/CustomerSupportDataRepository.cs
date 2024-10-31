using System.Runtime.ExceptionServices;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Pitstop.CustomerSupportAPI.Repositories;

public class CustomerSupportDataRepository : ICustomerSupportDataRepository
{
    private string _connectionString;
    
    public CustomerSupportDataRepository(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    public async Task<IEnumerable<Rejection>> GetRejectionsAsync()
    {
        var rejections = new List<Rejection>();
        await using var conn = new SqlConnection(_connectionString);
        try
        {
            var rejectionSelection = (await conn.QueryAsync<Rejection>("select * from Rejection")).ToList();

            if (rejectionSelection.Count != 0)
            {
                rejections.AddRange(rejectionSelection);
            }
        }
        catch (SqlException ex)
        {
            HandleSqlException(ex);
        }

        return rejections;
    }
    
    private static void HandleSqlException(SqlException ex)
    {
        // rethrow original exception without poluting the stacktrace
        ExceptionDispatchInfo.Capture(ex).Throw();
    }
}