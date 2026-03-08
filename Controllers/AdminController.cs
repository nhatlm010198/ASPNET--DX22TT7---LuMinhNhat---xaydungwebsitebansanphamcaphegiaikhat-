using CoffeeShopWebsite.Models;
using System.Linq;
using System.Web.Mvc;

namespace CoffeeShopWebsite.Controllers
{
    public class AdminController : Controller
    {
        private CoffeeDbContext db = new CoffeeDbContext();

        private bool IsAdmin()
        {
            return Session["Role"] != null && Session["Role"].ToString() == "Admin";
        }

        public ActionResult Index()
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");
            return View();
        }

        public ActionResult Products()
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");
            var products = db.Products.ToList();
            return View(products);
        }

        public ActionResult CreateProduct() => View();

        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Products");
            }
            return View(product);
        }

        public ActionResult DeleteProduct(int id)
        {
            var product = db.Products.Find(id);
            if (product != null)
            {
                db.Products.Remove(product);
                db.SaveChanges();
            }
            return RedirectToAction("Products");
        }
    }
}
