using Microsoft.AspNetCore.Mvc;
//Adding model
using Day27_MvcDemo.Models; // Uncomment if you have a Product model to use

namespace Day27_MvcDemo.Controllers
{
    public class ProductsController : Controller
    {
        //Controllers are responsible for handling user input and returning responses

        // get: /Products/Index
        /* public IActionResult Index()
         {
             var products = new List<Product>
             {
                 new Product { Id = 1, Name = "Laptop", Price = 999.00M },
                 new Product { Id = 2, Name = "Smartphone", Price = 250.00M },
                 new Product { Id = 3, Name = "Tablet", Price = 550.00M }

             };
             return View(products); // Passing the list of products to the view

         }

         // GET: /Products/Create (Displaying the form to create a new product)
         public IActionResult Create()
         {
             return View(); // Returning the view for creating a new product
         }

         // POST: /Products/Create (Handling the form submission)
         [HttpPost]
         //To prevent attack
         [ValidateAntiForgeryToken] // This attribute helps prevent CSRF attacks

         public IActionResult Create(Product product)
         {
             //Here modelState is used to validate the incoming product data it returns true if the model is valid and false if there are validation errors
             if (ModelState.IsValid) // Checking if the model state is valid
             {
                 // Here you would typically save the product to a database
                 // For demonstration, we will just redirect to the Index action

                 return RedirectToAction("Index");
             }
             // If the model state is not valid, return the same view with validation errors
             return View(product);
         }
        */

        private static List<Product> products = new List<Product>
    {
        new Product { Id = 1, Name = "Laptop", Price = 999.00M },
        new Product { Id = 2, Name = "Smartphone", Price = 250.00M },
        new Product { Id = 3, Name = "Tablet", Price = 550.00M }
    };

        // GET: /Products/Index
        public IActionResult Index()
        {
            return View(products); // Show all products
        }

        // GET: /Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                // Generate Id (simple auto-increment simulation)
                product.Id = products.Max(p => p.Id) + 1;
                products.Add(product);

                return RedirectToAction("Index");
            }
            return View(product);
        }
    }
}
