using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Models.Entities;
using Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class OrderController : Controller
    {
        IOrderRepository orderRepo = new OrderRepository();

        // GET: Order
        public ActionResult Index()
        {
            Console.WriteLine("I'm in Order");
            return View();
        }


       // [Authorize(Roles = "Administrator")]
        public ActionResult manageOrder()
        {
            var orders = orderRepo.getAll();
            if (User.IsInRole("Administrator"))
            {
                return View(orders);
            }
            var userOrders = new List<Order>();
            foreach (var order in orders)
            {
                var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                var currentUser = manager.FindById(User.Identity.GetUserId());
               
                if (order.Username.Equals(currentUser.UserName))
                {
                    userOrders.Add(order);
                }
            }
            return View(userOrders);
        
        }
        public ActionResult slipPath(FormCollection collection, HttpPostedFileBase file)
        {

            return View();
        }
        [HttpGet]
        public ActionResult Detail(int orderId)
        {
            Order order = orderRepo.getOrderById(orderId);
            return View(order);
        }

        [HttpPost]
        public ActionResult Detail(int orderId, FormCollection collection,string isCon, string isP)
        {
            Order order = orderRepo.getOrderById(orderId);

            var mtCost = double.Parse(collection["mountainCost"]);
            var tohCost = double.Parse(collection["toHomeCost"]);
            var costTotal = mtCost + tohCost;
            if (order.mountainCost==0 & order.toHomeCost==0)
            {
                order.mountainCost = mtCost;
                order.toHomeCost = tohCost;
                order.Total = order.Total + (decimal)costTotal;
            }
            else
            {
                var prvCost = order.mountainCost + order.toHomeCost;
                order.Total = order.Total-(decimal)prvCost;
                order.mountainCost = mtCost;
                order.toHomeCost = tohCost;
                order.Total = order.Total+(decimal)costTotal;
            }
           
            order.isConfirm = isCon;
            order.isPay = isP;
            
            
            orderRepo.saveOrder();


            return RedirectToAction("Detail", new { orderId = orderId });
        }



    }
}