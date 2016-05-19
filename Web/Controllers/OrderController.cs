using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index(int orderId)
        {
            Console.WriteLine("I'm in Order");
            return View();
        }
    }
}