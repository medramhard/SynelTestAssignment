using AutoMapper;
using DataAccessLibrary.Data;
using FakeItEasy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using Syncfusion.EJ2.Base;
using SynelEmployees.Controllers;
using SynelEmployees.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynelEmployees.Tests;
public class EmployeesControllerTests
{
    private IWebHostEnvironment _env;
    private IEmployeesData _db;
    private IMapper _mapper;
    private EmployeesController _employeesController;

    public EmployeesControllerTests()
    {
        // Dependencies
        _env = A.Fake<IWebHostEnvironment>();
        _db = A.Fake<IEmployeesData>();
        _mapper = A.Fake<IMapper>();

        // SUT
        _employeesController = new EmployeesController(_env, _db, _mapper);
    }

    [Fact]
    public void UploadFile_ShouldRedirectToLoadData()
    {
        // Arrange
        var file = A.Fake<IFormFile>();
        string expected = "LoadData";

        // Actual
        var actual = _employeesController.UploadFile(file) as RedirectToActionResult;

        // Assert
        Assert.Equal(expected, actual?.ActionName);
    }

    [Fact]
    public void LoadData_ShouldRedirectToIndex()
    {
        // Arrange
        string expected = "Index";

        // Actual
        var actual = _employeesController.LoadData() as RedirectToActionResult;

        // Assert
        Assert.Equal(expected, actual?.ActionName);
    }

    [Fact]
    public void UpdateData_ShouldUpdateProperly()
    {
        // Arrange
        var employee = A.Fake<CRUDModel<EmployeeDisplayModel>>();
        var expected = "{}";

        // Actual
        var actual = _employeesController.UpdateData(employee).ToJson();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async void SaveData_ShouldRedirectToIndex()
    {
        // Arrange
        string expected = "Index";

        // Actual
        var actual = await _employeesController.SaveData() as RedirectToActionResult;

        // Assert
        Assert.Equal(expected, actual?.ActionName);
    }
}
