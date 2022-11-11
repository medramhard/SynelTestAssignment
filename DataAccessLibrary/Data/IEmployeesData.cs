using DataAccessLibrary.Models;

namespace DataAccessLibrary.Data;
public interface IEmployeesData
{
    Task<int> Save(IEnumerable<EmployeeModel> employees);
}