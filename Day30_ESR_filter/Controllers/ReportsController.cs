using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EmployeesManagement.Models;
using EmployeesManagement.Filters;

namespace EmployeesManagement.Controllers;

[Route("reports")]
public class ReportsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    [HttpGet("salary")]
    [ServiceFilter(typeof(AuthorizationFilter))]
    public IActionResult Salary() => Content("Salary report: [confidential]");

}