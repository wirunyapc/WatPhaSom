using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entities;
using Models.EF;
using System.Data.Entity;

namespace Models.Repositories
{
    class ProductRepository : IProductRepository
    {
        EFDbContext _context = new EFDbContext();

        public void addProduct(Product product)
        {
            _context.Products.Add(product);
            saveProduct();

            
        }

        public void deleteProduct(string id)
        {
            Product product = _context.Products.Find(id);
            _context.Products.Remove(product);
            saveProduct();
        }

        public void editProduct(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            saveProduct();
        }

       // public List<Product> getAll()
        //{
         //   IEnumerable<Product> GetProducts();
        //}

        public Product getProductById(string id)
        {
            Product product = _context.Products.Find(id);
            return product;
        }

        public void saveProduct()
        {
            _context.SaveChanges();
        }
    }
}
