using System;
using System.Linq;
using System.Web.Mvc;
using CoffeeShopWebsite.Models;

namespace CoffeeShopWebsite.Controllers
{
    public class HomeController : Controller
    {
        private CoffeeDbContext db = new CoffeeDbContext();

        // Trang chủ
        public ActionResult Index()
        {
            // Lấy 6 sản phẩm mới nhất
            var products = db.Products
                             .OrderByDescending(p => p.ProductId)
                             .Take(6)
                             .ToList();

            return View(products);
        }

        // Trang giới thiệu
        public ActionResult About()
        {
            ViewBag.Message = "Giới thiệu về cửa hàng cà phê.";

            return View();
        }

        // Trang liên hệ
        public ActionResult Contact()
        {
            ViewBag.Message = "Liên hệ với chúng tôi.";

            return View();
        }

        // Trang danh mục sản phẩm theo loại
        public ActionResult Category(int id)
        {
            var products = db.Products
                             .Where(p => p.CategoryId == id)
                             .ToList();

            var category = db.Categories.Find(id);

            ViewBag.CategoryName = category != null ? category.CategoryName : "Danh mục";

            return View(products);
        }

        // Tìm kiếm sản phẩm
        public ActionResult Search(string keyword)
        {
            var products = db.Products
                             .Where(p => p.ProductName.Contains(keyword))
                             .ToList();

            ViewBag.Keyword = keyword;

            return View(products);
        }
    }
}
