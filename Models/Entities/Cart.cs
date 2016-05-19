using Models.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace Models.Entities
{
    public class Cart
    {
        public const string CartSessionKey = "CartId";
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
        public List<CartLine> GetCartLines()
        {
            return lineCollection;
        }
       
        public Order CreateOrder(Order order)
        {
            double orderTotal = 0;
            order.OrderDetails = new List<OrderDetail>();

            var cartLines = GetCartLines();
            // Iterate over the items in the cart, 
            // adding the order details for each
            foreach (var line in cartLines)
            {
                var orderDetail = new OrderDetail
                {
                    productId = line.Product.productId,
                    OrderId = order.OrderId,                 
                    Quantity = cartLines.Count
                };
                // Set the order total of the shopping cart
              
                    orderTotal += (line.Product.priceRetail * line.Quantity);
                    order.OrderDetails.Add(orderDetail);
                    //storeDB.OrderDetails.Add(orderDetail);
                
                
            }
            // Set the order's total to the orderTotal count
            order.Total = orderTotal;

            // Save the order
           
            // Empty the shopping cart
            Clear();
            // Return the OrderId as the confirmation number
            return order;
        }
        public Order CreateOrderWholesale(Order order)
        {
            double orderTotal = 0;
            order.OrderDetails = new List<OrderDetail>();

            var cartLines = GetCartLines();
            // Iterate over the items in the cart, 
            // adding the order details for each
            foreach (var line in cartLines)
            {
                var orderDetail = new OrderDetail
                {
                    productId = line.Product.productId,
                    OrderId = order.OrderId,
                    Quantity = cartLines.Count
                };
                // Set the order total of the shopping cart
              
                orderTotal += (line.Product.priceWholesale * line.Quantity);
                order.OrderDetails.Add(orderDetail);
            }
            // Set the order's total to the orderTotal count
            order.Total = orderTotal;

            // Save the order
            // Empty the shopping cart
            Clear();
            // Return the OrderId as the confirmation number
            return order;
        }
    }
}