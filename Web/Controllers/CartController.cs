using Models.Entities;
using Models.Repositories;
using Models.ViewModels;
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
        public CartController()
        {
            repository = new ProductRepository();
        }
        public CartController(IProductRepository repo) { repository = repo; }

        public ActionResult Index(string returnUrl)
        {

            Cart cart = GetCart();

            return View(new CartIndexViewModel
            {

                Cart = cart,
                ReturnUrl = returnUrl

            });
        }

        public RedirectToRouteResult AddToCart(int productId, string returnUrl )
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
      /*  public RedirectToRouteResult UpdateLine(int productId, int newQuantity, string returnUrl)
        {

            Product product = repository.getProductById(productId);

            if (product != null)
            {
                Cart cart = GetCart();
                cart.UpdateLine(product, newQuantity);
                Session["Cart"] = cart;
            }
            return RedirectToAction("Index", new { returnUrl });
        }*/

        public Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"]; if (cart == null) { cart = new Cart(); Session["Cart"] = cart; }
            return cart;
        }
       

    }
}