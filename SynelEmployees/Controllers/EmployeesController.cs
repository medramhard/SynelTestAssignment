﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using SynelEmployees.Models;
using DataAccessLibrary.Data;
using AutoMapper;
using DataAccessLibrary.Models;
using Syncfusion.EJ2.Base;

namespace SynelEmployees.Controllers;
public class EmployeesController : Controller
{
    private readonly IWebHostEnvironment _env;
    private readonly IEmployeesData _db;
    private readonly IMapper _mapper;
    private static string _rowsAffected = string.Empty;
    private static List<EmployeeDisplayModel> _employees = new();

    public EmployeesController(IWebHostEnvironment env, IEmployeesData db, IMapper mapper)
    {
        _env = env;
        _db = db;
        _mapper = mapper;
    }

    private List<EmployeeDisplayModel> GetAllEmployees()
    {
        var filePath = $"{_env.ContentRootPath}Files\\dataset.csv";
        List<EmployeeDisplayModel> output = new();
        List<string> records = GetRecords(filePath);

        foreach (var record in records)
        {
            var values = record.Split(',');

            if (values.Length < 11)
            {
                throw new Exception("Invalid record");
            }

            EmployeeDisplayModel employee = new()
            {
                PayrollNumber = values[0],
                Forename = values[1],
                Surname = values[2],
                BirthDate = DateTime.Parse(values[3]),
                Phone = values[4],
                CellPhone = values[5],
                StreetAddress = values[6],
                City = values[7],
                Postcode = values[8],
                Email = values[9],
                StartDate = DateTime.Parse(values[10])
            };

            output.Add(employee);
        }

        return output;
    }

    private List<string> GetRecords(string filePath)
    {
        if (System.IO.File.Exists(filePath) == false)
        {
            return new List<string>();
        }

        var file = System.IO.File.ReadAllLines(filePath).Where(l => l != string.Empty).ToList();
        file.RemoveAt(0);

        return file;
    }

    public IActionResult Index()
    {
        ViewBag.RowsAffected = _rowsAffected;
        return View(_employees);
    }

    public IActionResult UploadFile(IFormFile file)
    {
        Directory.CreateDirectory($"{_env.ContentRootPath}Files");
        var dir = $"{_env.ContentRootPath }Files";

        if (file?.Length > 0)
        {
            using var fileStream = new FileStream(Path.Combine(dir, "dataset.csv"), FileMode.Create, FileAccess.Write);
            file.CopyTo(fileStream);
        }

        return RedirectToAction("LoadData");
    }

    public IActionResult LoadData()
    {
        _employees = GetAllEmployees();

        return RedirectToAction("Index");
    }

    public IActionResult UpdateData([FromBody]CRUDModel<EmployeeDisplayModel> employee)
    {
        var row = _employees.Where(e => e.PayrollNumber == employee.Value.PayrollNumber).FirstOrDefault();
        if (row != null)
        {
            row.PayrollNumber = employee.Value.PayrollNumber;
            row.Forename= employee.Value.Forename;
            row.Surname = employee.Value.Surname;
            row.BirthDate = employee.Value.BirthDate;
            row.Phone= employee.Value.Phone;
            row.CellPhone= employee.Value.CellPhone;
            row.StreetAddress = employee.Value.StreetAddress;
            row.City = employee.Value.City;
            row.Postcode = employee.Value.Postcode;
            row.Email = employee.Value.Email;
            row.StartDate = employee.Value.StartDate;
        }

        return Json(employee.Value);
    }

    public async Task<IActionResult> SaveData()
    {
        List<EmployeeModel> employees = _mapper.Map<List<EmployeeModel>>(_employees);
        int rowsAffected = await _db.Save(employees);
        _rowsAffected = string.Format("Number of rows affected: {0}", rowsAffected);
        _employees = new();

        return RedirectToAction("Index");
    }
}
