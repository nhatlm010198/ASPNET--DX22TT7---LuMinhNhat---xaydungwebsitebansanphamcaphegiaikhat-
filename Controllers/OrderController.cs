using CoffeeShopWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CoffeeShopWebsite.Controllers
{
    public class OrderController : Controller
    {
        private CoffeeDbContext db = new CoffeeDbContext();

        public ActionResult AddToCart(int id)
        {
            var product = db.Products.Find(id);
            if (product == null) return HttpNotFound();

            var cart = Session["Cart"] as List<OrderDetail> ?? new List<OrderDetail>();

            var existing = cart.FirstOrDefault(x => x.ProductId == id);
            if (existing != null)
                existing.Quantity++;
            else
                cart.Add(new OrderDetail { ProductId = id, Product = product, Quantity = 1, UnitPrice = product.Price });

            Session["Cart"] = cart;
            return RedirectToAction("Cart");
        }

        public ActionResult Cart()
        {
            var cart = Session["Cart"] as List<OrderDetail> ?? new List<OrderDetail>();
            return View(cart);
        }

        public ActionResult Checkout()
        {
            if (Session["User"] == null) return RedirectToAction("Login", "Account");

            var user = (User)Session["User"];
            var cart = Session["Cart"] as List<OrderDetail>;

            var order = new Order
            {
                OrderDate = DateTime.Now,
                Status = "Chờ xác nhận",
                UserId = user.UserId,
                OrderDetails = new List<OrderDetail>()
            };

            foreach (var item in cart)
            {
                item.Product = null;
                order.OrderDetails.Add(item);
            }

            db.Orders.Add(order);
            db.SaveChanges();
            Session["Cart"] = null;

            return RedirectToAction("Success");
        }

        public ActionResult Success() => View();
    }
}

