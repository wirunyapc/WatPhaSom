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
   public class ProductRepository : IProductRepository
    {
        EFDbContext _context = new EFDbContext();

        public void addProduct(Product product)
        {
            _context.Products.Add(product);
            saveProduct();

            
        }

        public void deleteProduct(Product product)
        {
            _context.Products.Remove(product);
            saveProduct();
        }

        public void editProduct(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            saveProduct();
        }

        public List<Product> getAll()
        {

            return _context.Products.ToList();
                
        }

        public Product getProductById(int id)
        {
            Product product = _context.Products.First(p => p.productId.Equals(id));
            return product;
        }

        public void saveProduct()
        {
            _context.SaveChanges();
        }
    }
}
