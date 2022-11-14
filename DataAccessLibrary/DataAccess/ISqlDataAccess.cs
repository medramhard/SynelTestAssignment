namespace DataAccessLibrary.DataAccess;

/// <summary>
/// Provides CRUD operations on a SQL Server database
/// </summary>
public interface ISqlDataAccess
{
    Task<List<T>> LoadData<T, U>(string storedProcedure, U parameters);
    Task SaveData<T>(string storedProcedure, T parameters);
}