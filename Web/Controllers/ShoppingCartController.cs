using Models.EF;
using Models.Repositories;
using Models.ViewModel;
using System.Linq;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart

        IShoppingCartRepository ShoppingCart = new ShoppingCartRepository();
        EFDbContext storeDB = new EFDbContext();
        //
        // GET: /ShoppingCart/
        public ActionResult Index()
        {
            string role = null;
            if (User.IsInRole("Retail"))
            {
                role = "Retail";
            }
            else
            {
                role = "Wholesale";
            }

            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Set up our ViewModel
            var viewModel = new ShoppingCartViewModel
            {

                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal(role)
            };
            // Return the view
            return View(viewModel);
        }
        //
        // GET: /Store/AddToCart/5
        [HttpPost]
        public ActionResult AddToCart(int amount, int productId)
        {
            // Retrieve the item from the database
            var addedItem = storeDB.Products
                .Single(Product => Product.productId.Equals(productId));

            // Add it to the shopping cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

            int count = amount;
            int sum = cart.GetCount() + amount;
            cart.AddToCart(addedItem, amount);
            // Display the confirmation message
            string role = null;
            if (User.IsInRole("Retail"))
            {
                role = "Retail";
            }
            else
            {
                role = "Wholesale";
            }
            var results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(addedItem.name) +
                    " has been added to your shopping cart.",

                CartTotal = cart.GetTotal(role),
                CartCount = sum,
                ItemCount = sum,
                DeleteId = productId
            };
            return RedirectToAction("Index");

            // Go back to the main store page for more shopping
            // return RedirectToAction("Index");
        }
        //
        // AJAX: /ShoppingCart/RemoveFromCart/5
        [HttpPost]
        public ActionResult RemoveFromCart(int ProductId)
        {
            // Remove the item from the cart
            var cart = ShoppingCart.GetCart(this.HttpContext);
            cart.RemoveFromCart(ProductId);

            // Get the name of the item to display confirmation

            // Get the name of the album to display confirmation
            /*string itemName = storeDB.Products
                .Single(item => item.productId.ToString() == ProductId.ToString()).name;


            // Remove from cart
            int itemCount = cart.RemoveFromCart(ProductId);
            string role = null;
            if (User.IsInRole("Retail"))
            {
                role = "Retail";
            }
            else
            {
                role = "Wholesale";
            }
            // Display the confirmation message
            var results = new ShoppingCartRemoveViewModel
            {
                Message = "One (1) " + Server.HtmlEncode(itemName) +
                    " has been removed from your shopping cart.",
                CartTotal = cart.GetTotal(role),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = ProductId
            };*/
            return RedirectToAction("Index");
        }
        //
        // GET: /ShoppingCart/CartSummary
        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }
    }
}