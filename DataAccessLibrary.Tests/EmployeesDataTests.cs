using Autofac.Extras.Moq;
using DataAccessLibrary.Data;
using DataAccessLibrary.DataAccess;
using DataAccessLibrary.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Tests;
public class EmployeesDataTests
{
    [Fact]
    public async void SaveAll_ShouldSucceed()
    {
        // Arrange
        using var mock = AutoMock.GetLoose();
        List<EmployeeModel> employees = GetPeople();
        mock.Mock<ISqlDataAccess>()
            .Setup(x => x.SaveData("[dbo].[spEmployee_Add]", employees));
        var cls = mock.Create<EmployeesData>();
        int expected = 1;

        // Actual
        int actual = await cls.SaveAll(employees);

        // Assert
        Assert.Equal(expected, actual);
    }

    private List<EmployeeModel> GetPeople()
    {
        List<EmployeeModel> output = new();

        EmployeeModel employee = new EmployeeModel()
        {
            PayrollNumber = "COOP08",
            Forename = "John",
            Surname = "Williams"
        };

        output.Add(employee);

        return output;
    }
}
