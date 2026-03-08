using CoffeeShopWebsite.Models;
using System.Linq;
using System.Web.Mvc;

namespace CoffeeShopWebsite.Controllers
{
    public class ProductController : Controller
    {
        private CoffeeDbContext db = new CoffeeDbContext();

        // GET: /Product/
        public ActionResult Index()
        {
            var products = db.Products.Include("Category").ToList();
            return View(products);
        }

        // GET: /Product/Details/5
        public ActionResult Details(int id)
        {
            var product = db.Products.Find(id);
            if (product == null) return HttpNotFound();
            return View(product);
        }
    }
}
