using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EmployeesManagement.Models;
using EmployeesManagement.Filters;
using System.Threading;
namespace EmployeesManagement.Controllers
{
    [Route("orders")]
    [ServiceFilter(typeof(ExceptionFilter))]
    public class OrdersController : Controller
    {
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(ILogger<OrdersController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            throw new Exception("Test exception from Index");
            // return Content("Orders Index");
        }


        [HttpGet("error-test")]
        // [ServiceFilter(typeof(ExceptionFilter))]
        public IActionResult ErrorTest()
        {
            throw new Exception("Test exception");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            throw new Exception("Test exception from Create");
        }


        [HttpGet("{id:int}")]
        [ServiceFilter(typeof(LoggingActionFilter))]
        public IActionResult Get(int id)
        {
            Thread.Sleep(1000);
            return Ok(new { Id = id, Status = "OK" });

        }


    }
}