using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using Models.Repositories;
using Models.Entities;

namespace Web.Controllers
{
    public class ProductController : Controller
    {

        IProductRepository productRepo = new ProductRepository();
        // GET: Product
        public ActionResult Index()
        {

            return View(productRepo.getAll());
        }

        public ActionResult manageProduct()
        {

            return View(productRepo.getAll());
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View(productRepo.getProductById(id));
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            Product product = new Product();

            var description = collection["description"];
            var name = collection["name"];
            var price = collection["price"];
            var path = collection["photoPath"];

            double ConvertNum = double.Parse(price);
            
            product.name = name;
            product.price = ConvertNum;
            product.description = description;
            product.photoPath = path;

            productRepo.addProduct(product);

            return RedirectToAction("Index");
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
