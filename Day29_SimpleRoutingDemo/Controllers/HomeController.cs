using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Day29_SimpleRoutingDemo.Models;

namespace Day29_SimpleRoutingDemo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    // EvenOnly
    // [HttpGet("evenonly/{id:int}")]
    // Works only for even numbers
    public IActionResult EvenOnly(int id)
    {
        return Content($"The number {id} is even.");
    }

    // OddOnly
    // [HttpGet("oddonly/{id:int}")]
    // Works only for odd numbers
    public IActionResult OddOnly(int id)
    {
        return Content($"The number {id} is odd.");
    }

    // AnyId
    // [HttpGet("anyid/{id:int}")]
    // Works for any number
    public IActionResult AnyId(int id)
    {
        return Content($"Any route matched with id: {id} is Valid.");
    }

    // Special
    // [HttpGet("special/{id:int}")]
    public IActionResult Special()
    {
        return Content($"Special route matched dynamically.");
    }
}
