using Day29_BlogDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day29_BlogDemo.Controllers
{
    // Product controller for managing products
    public class ProductController : Controller
    {
        // In-memory data store
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 4, Name = "Toyota Camry", Description = "Reliable midsize sedan", Price = 25000 },
            new Product { Id = 5, Name = "Honda Civic", Description = "Compact car with great fuel efficiency", Price = 22000 },
            new Product { Id = 6, Name = "Ford Mustang", Description = "Classic American sports car", Price = 35000 }
        };

        // Action methods
        // Create Product
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                products.Add(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // Index
        public IActionResult Index()
        {
            return View(products);
        }

        // Details
        public IActionResult Details(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
    }
}