using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Repositories;
using Models.Entities;
using System.IO;

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
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

       
          
        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, HttpPostedFileBase file)
        {
            Product product = new Product();
            string path=null;
             if (file != null)
                 {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string imagePath = System.IO.Path.Combine(
                                       Server.MapPath("~/photoUpload"), pic);
                // file is uploaded
                file.SaveAs(imagePath);
                path = "~/photoUpload/" + pic;
                 }



            var description = collection["description"];
            var name = collection["name"];
            var price = collection["price"];

            double ConvertNum = double.Parse(price);
            
            product.name = name;
            product.price = ConvertNum;
            product.description = description;
            product.photoPath = path;

            productRepo.addProduct(product);

            return RedirectToAction("manageProduct");
        }

        // GET: Product/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(productRepo.getProductById(id));
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection, HttpPostedFileBase file)
        {
            try
            {

                // TODO: Add update logic here
                Product product = productRepo.getProductById(id);

                string path = null;
                if (file != null)
                {
                    System.Diagnostics.Debug.WriteLine("Hello i'm here");
                    string pic = System.IO.Path.GetFileName(file.FileName);
                    string imagePath = System.IO.Path.Combine(
                                           Server.MapPath("~/photoUpload"), pic);
                    // file is uploaded
                    file.SaveAs(imagePath);
                    path = "~/photoUpload/" + pic;
                }

                var description = collection["description"];
                var name = collection["name"];
                var price = collection["price"];

                double ConvertNum = double.Parse(price);

                product.name = name;
                product.price = ConvertNum;
                product.description = description;

                //edit Photo
                product.photoPath = path;

                productRepo.editProduct(product);


                return RedirectToAction("manageProduct");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/
        [HttpGet]
      public ActionResult Delete(int id)
        {
            return View(productRepo.getProductById(id));
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Product product = productRepo.getProductById(id);
                productRepo.deleteProduct(product);
                return RedirectToAction("manageProduct");
            }
            catch
            {
                return View();
            }
        }
    }
}
