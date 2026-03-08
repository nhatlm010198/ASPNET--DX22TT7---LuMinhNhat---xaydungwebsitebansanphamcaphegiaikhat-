using CoffeeShopWebsite.Models;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace CoffeeShopWebsite.Controllers
{
    public class AccountController : Controller
    {
        private CoffeeDbContext db = new CoffeeDbContext();

        // GET: /Account/Register
        public ActionResult Register() => View();

        // POST: /Account/Register
        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                user.Role = UserRole.Customer;
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(user);
        }

        // GET: /Account/Login
        public ActionResult Login() => View();

        // POST: /Account/Login
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var user = db.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user != null)
            {
                Session["User"] = user;
                Session["Role"] = user.Role.ToString();
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Message = "Sai thông tin đăng nhập";
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}

