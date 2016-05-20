﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Models.EF;
using Models.Entities;
using Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        EFDbContext storeDB = new EFDbContext();
        IShoppingCartRepository ShoppingCart = new ShoppingCartRepository();

        //public List<String> CreditCardTypes { get { return appConfig.CreditCardType; } }

        //
        // GET: /Checkout/AddressAndPayment
        public ActionResult Address()
        {
            string ro = null; // roles
            if (User.IsInRole("Retail"))
            {
                ro = "Retail";
            }
            if (User.IsInRole("Wholesale"))
            {
                ro = "Wholesale";
            }
            //ViewBag.CreditCardTypes = CreditCardTypes;
            var previousOrder = storeDB.Orders.FirstOrDefault(x => x.Username == User.Identity.Name);
            var cart = ShoppingCart.GetCart(this.HttpContext);
            decimal total = cart.GetTotal(ro);
            if (previousOrder != null)
                return View(previousOrder);
            else
                return View();
        }

        //
        // POST: /Checkout/AddressAndPayment
        [HttpPost]
        public async Task<ActionResult> Address(FormCollection values)
        {
            string ro = null; // roles
            if (User.IsInRole("Retail"))
            {
                ro = "Retail";
            }
            if (User.IsInRole("Wholesale"))
            {
                ro = "Wholesale";
            }

            string pathimage = null;

          /*  if (file != null)
            {
                //string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/Content/Images/TransferSlip/"));
                // file is uploaded
                string extension = System.IO.Path.GetExtension(file.FileName);
                string fileName = file.FileName;
                file.SaveAs(System.IO.Path.Combine(path, fileName + extension));

                //file.SaveAs(path);
                pathimage = "~/Content/Images/TransferSlip/" + fileName + extension;
            }*/
            //string result = values[9];
            var cart = ShoppingCart.GetCart(this.HttpContext);
            decimal total = cart.GetTotal(ro);
            var order = new Order();
            TryUpdateModel(order);
            //order.CreditCard = result;

            try
            {
                order.Username = User.Identity.Name;
                order.Email = User.Identity.Name;
                order.OrderDate = DateTime.Now;
                order.Total = total;
                order.slipPath = pathimage;
                order.isConfirm = "-";
                var currentUserId = User.Identity.GetUserId();

                if (order.SaveInfo && !order.Username.Equals("guest@guest.com"))
                {

                    var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                    var store = new UserStore<ApplicationUser>(new ApplicationDbContext());
                    var ctx = store.Context;
                    var currentUser = manager.FindById(User.Identity.GetUserId());

                    order.Address = values["Address"];
                    order.City = values["City"];
                    order.Country = values["Country"];
                    order.State = values["State"];
                    order.Phone = values["Phone"];
                    order.PostalCode = values["PostalCode"];
                    currentUser.FirstName = values["FirstName"];
                    currentUser.LastName = values["FirstName"];



                    //Save this back
                    //http://stackoverflow.com/questions/20444022/updating-user-data-asp-net-identity
                    //var result = await UserManager.UpdateAsync(currentUser);
                    await ctx.SaveChangesAsync();

                    await storeDB.SaveChangesAsync();
                }


                //Save Order
                storeDB.Orders.Add(order);
                await storeDB.SaveChangesAsync();
                //Process the order
                //var cart = ShoppingCart.GetCart(this.HttpContext);
                order = cart.CreateOrder(order);



                //CheckoutController.SendOrderMessage(order.FirstName, "New Order: " + order.OrderId, order.ToString(order), appConfig.OrderEmail);

                return RedirectToAction("Complete",
                    new { id = order.OrderId });

            }
            catch
            {
                //Invalid - redisplay with errors
                return View(order);
            }
        }

        //
        // GET: /Checkout/Complete
        public ActionResult Complete(int id)
        {
            // Validate customer owns this order
            bool isValid = storeDB.Orders.Any(
                o => o.OrderId == id &&
                o.Username == User.Identity.Name);

            if (isValid)
            {
                return View(id);
            }
            else
            {
                return View("Error");
            }
        }

        
    }
}