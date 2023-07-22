using BLL;
using BOL;
using DAL;
using Microsoft.AspNetCore.Mvc;

namespace PMS.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult getProductDetails() {
            List<Product> products = ProductService.getAllProdList();
            ViewBag.ProductDetails = products;
            return View();
        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insert(string id,string nm, string desc, string cat, string price, string mfg) { 
            Product product = new Product(int.Parse(id),nm,desc,Enum.Parse<Category>(cat),double.Parse(price),DateOnly.FromDateTime(DateTime.Parse(mfg)));
            
            ProductService.addNewProduct(product);

            return RedirectToAction("getProductDetails");
        }

        
    }
}
