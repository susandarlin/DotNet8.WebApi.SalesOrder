using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace DotNet8.WebApi.SalesOrder.Services;

public class DapperService
{
    internal readonly IConfiguration _configuration;

    public DapperService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<List<T>> QueryAsync<T>(string query, object? parameter = null)
    {
        try
        {
            using IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DbConnection"));

            var lst = await db.QueryAsync<T>(query, parameter);

            return lst.ToList();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<T> QueryFirstOrDefaultAsync<T>(string query, object? parameter = null)
    {
        try
        {
            using IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DbConnection"));
            var item = await db.QueryFirstOrDefaultAsync<T>(query, parameter);
            return item!;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<int> ExecuteAsync(string query, object parameter)
    {
        try
        {
            using IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DbConnection"));

            var result = await db.ExecuteAsync(query, parameter);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
