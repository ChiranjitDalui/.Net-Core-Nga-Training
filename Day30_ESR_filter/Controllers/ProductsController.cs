using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EmployeesManagement.Models;
using EmployeesManagement.Filters;
 
 
namespace EmployeesManagement.Controllers;

public class ProductsController : Controller
{
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(ILogger<ProductsController> logger)
    {
        _logger = logger;
    }

    [HttpGet("products/{id:int}")]
    [ServiceFilter(typeof(ProductCacheResourceFilter))]
            public IActionResult Get(int id)
        {
            ContentResult contentResult = new ContentResult
            {
                Content = $"Details for product id: {id} fetched at " + DateTime.UtcNow,
                ContentType = "text/plain"
            };
            return contentResult;
        }



    // public IActionResult Details(int id)
    // {
    //     // Here you would typically fetch the product details from a database
    //     return View(new Product { Id = id, Name = "Sample Product", Price = 9.99M });
    // }
}