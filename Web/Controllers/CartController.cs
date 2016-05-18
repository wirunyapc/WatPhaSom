using Models.Entities;
using Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        private IProductRepository repository;
        public CartController(IProductRepository repo) { repository = repo; }
        public ActionResult Index()
        {
            var isRetail = User.IsInRole("Retail");
            // System.Diagnostics.Debug.WriteLine(((ClaimsPrincipal)User).Identities);
            return isRetail ? RedirectToAction("cartRetail") : RedirectToAction("cartWholesale");
        }
        public ViewResult cartRetail(string returnUrl) { return View(new CartIndexViewModel { Cart = GetCart(), ReturnUrl = returnUrl }); }
        public ViewResult cartWholesale(string returnUrl) { return View(new CartIndexViewModel { Cart = GetCart(), ReturnUrl = returnUrl }); }

        public RedirectToRouteResult AddToCart(int productId, string returnUrl)
        {
            Product product = repository.getProductById(productId);
            if (product != null) { GetCart().AddItem(product, 1); }
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToRouteResult RemoveFromCart(int productId, string returnUrl)
        {
            Product product = repository.getProductById(productId);
            if (product != null) { GetCart().RemoveLine(product); }
            return RedirectToAction("Index", new { returnUrl });
        }
        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"]; if (cart == null) { cart = new Cart(); Session["Cart"] = cart; }
            return cart;
        }
    }
}