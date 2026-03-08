using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CafeShopMVC.Models;

namespace CafeShopMVC.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            List<Product> products = new List<Product>()
            {
                new Product{Id=1, Name="Cà phê sữa", Price=25000},
                new Product{Id=2, Name="Cà phê đen", Price=20000},
                new Product{Id=3, Name="Bạc xỉu", Price=30000}
            };

            return View(products);
        }
    }
}
