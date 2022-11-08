using Microsoft.AspNetCore.Mvc;

namespace SynelEmployees.Controllers;
public class EmployeesController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
