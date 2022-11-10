using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using SynelEmployees.Models;

namespace SynelEmployees.Controllers;
public class EmployeesController : Controller
{
    private readonly IWebHostEnvironment _env;

    public EmployeesController(IWebHostEnvironment env)
    {
        _env = env;
    }

    public IActionResult Index()
    {
        var filePath = $"{_env.ContentRootPath }Files\\dataset.csv";
        List<EmployeeDisplayModel> employees = new();
        employees = GetAllEmployees(filePath);

        return View(employees);
    }

    private List<EmployeeDisplayModel> GetAllEmployees(string filePath)
    {
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

    [HttpPost]
    public IActionResult UploadFile(IFormFile file)
    {
        var dir = $"{_env.ContentRootPath }Files";

        if (file?.Length > 0)
        {
            using var fileStream = new FileStream(Path.Combine(dir, "dataset.csv"), FileMode.Create, FileAccess.Write);
            file.CopyTo(fileStream);
        }

        return RedirectToAction("Index");
    }
}
