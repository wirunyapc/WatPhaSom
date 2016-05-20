using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace Models.Entities
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();
        public void AddItem(Product product, int quantity)
        {
            CartLine line = lineCollection.Where(p => p.Product.productId == product.productId).FirstOrDefault();
            if (line == null) { lineCollection.Add(new CartLine { Product = product, Quantity = quantity }); } else { line.Quantity += quantity; }
        }
        public void RemoveLine(Product product) { lineCollection.RemoveAll(l => l.Product.productId == product.productId); }
        public double ComputeTotalValue(string userType)
        {
            if (userType.Equals("Wholesale"))
            {
                return lineCollection.Sum(e => e.Product.priceWholesale * e.Quantity);

            }
            return lineCollection.Sum(e => e.Product.priceRetail * e.Quantity);
        }
       
        public void Clear() { lineCollection.Clear(); }
        public IEnumerable<CartLine> Lines { get { return lineCollection; } }
    }
}