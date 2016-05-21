using Models.Entities;
using Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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


        [Authorize(Roles = "Administrator")]
        public ActionResult manageOrder()
        {                    
            return View(orderRepo.getAll());
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