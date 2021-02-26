using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class CartController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowCart(int id)
        {
            List<Product> cart = new List<Product>();
            Product product = db.products.Find(id);
            cart.Add(new Product()
            {
                Id = product.Id,
                Name = product.Name,
                img = product.img,
                Description = product.Description,
                Price = product.Price
            });
            return View(cart);
        }

        public ActionResult Pay()
        {
            return View();
        }

        public ActionResult CheckOut()
        {
            return View();
        }

        [HttpPost]

        public ActionResult CheckOut([Bind(Include = "Id,Name,LastName,Email,Address,State,Zip")] Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                db.purchases.Add(purchase);
                db.SaveChanges();
                return RedirectToAction("Pay");
            }
            return View();
        }


    }
}