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
   public class OrderRepository : IOrderRepository
    {
        EFDbContext _context = new EFDbContext();

        public void addOrder(Order order)
        {
            // Load current account from DB
            var accountInDb = _context.Orders.Single(a => a.orderId == order.orderId);

            // Update the properties
            _context.Entry(accountInDb).CurrentValues.SetValues(order);

            // Save the changes
            _context.SaveChanges();
        }

        public void deleteOrder(string id)
        {
            Order order = _context.Orders.Find(id);
            _context.Orders.Remove(order);
            saveOrder();
        }

        public void editOrder(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
            saveOrder();
        }

        public List<Order> getAll()
        {
            var orders = _context.Orders.ToList();
            return orders;
        }

        public Order getOrderById(int id)
        {
            Order order = _context.Orders.First(o => o.orderId.Equals(id));
            return order;
        }

        public void saveOrder()
        {
            _context.SaveChanges();
        }
    }
}
