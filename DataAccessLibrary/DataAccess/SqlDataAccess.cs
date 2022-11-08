using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLibrary.DataAccess;
public class SqlDataAccess : ISqlDataAccess
{
    private readonly IConfiguration _config;
    private readonly string _connectionString;
    private const string ConnectionStringName = "Default";

    public SqlDataAccess(IConfiguration config)
    {
        _config = config;
        _connectionString = GetConnectionString();
    }

    private string GetConnectionString()
    {
        return _config.GetConnectionString(ConnectionStringName);
    }

    public async Task<List<T>> LoadData<T, U>(string storedProcedure, U parameters)
    {
        using IDbConnection connection = new SqlConnection(_connectionString);

        return (await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure)).ToList();
    }

    public async Task SaveData<T>(string storedProcedure, T parameters)
    {
        using IDbConnection connection = new SqlConnection(_connectionString);

        await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }
}
