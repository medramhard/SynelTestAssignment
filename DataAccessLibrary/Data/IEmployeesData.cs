using DataAccessLibrary.Models;

namespace DataAccessLibrary.Data;
public interface IEmployeesData
{
    Task<int> Add(IEnumerable<EmployeeModel> employees);
}