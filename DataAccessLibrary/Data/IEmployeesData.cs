using DataAccessLibrary.Models;

namespace DataAccessLibrary.Data;

/// <summary>
/// Provides all the operation on the Employees database for the Employee table
/// </summary>
public interface IEmployeesData
{

    /// <summary>
    /// Saves all the employees to the database and returns a number of rows affected
    /// </summary>
    /// <param name="employees"></param>
    /// <returns>number of rows affected</returns>
    Task<int> SaveAll(IEnumerable<EmployeeModel> employees);
}