using DataAccessLibrary.DataAccess;
using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Data;

public class EmployeesData : IEmployeesData
{
    private readonly ISqlDataAccess _db;

    public EmployeesData(ISqlDataAccess db)
    {
        _db = db;
    }

    public async Task<int> Save(IEnumerable<EmployeeModel> employees)
    {
        int count = 0;

        foreach (var employee in employees)
        {
            await _db.SaveData("[dbo].[spEmployee_Add]", employee);
            count++;
        }

        return count;
    }
}
