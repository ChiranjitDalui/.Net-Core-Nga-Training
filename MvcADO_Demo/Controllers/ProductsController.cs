using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MvcADO_Demo.Data;


namespace MvcADO_Demo.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductsRepository _productsRepository;

        public ProductsController(ProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public IActionResult Index()
        {
            var productsDataSet = _productsRepository.GetProducts();
            return View(productsDataSet);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string name, decimal price)
        {
            if (price >= 0 && ModelState.IsValid)// ModelState.IsValid checks for validation attributes,it is used to check if the model is valid or not, Valid based on the data annotations applied to the model properties.
            {
                int newProductId = _productsRepository.InsertProduct(name, price);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id > 0)
            {
                _productsRepository.DeleteProduct(id);
            }
            return RedirectToAction("Index"); // Redirect back to the product list
        }
    }
}