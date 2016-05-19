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
            var accountInDb = _context.Orders.Single(a => a.OrderId == order.OrderId);

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
            return _context.Orders.ToList();
        }

        public Order getOrderById(string id)
        {
            Order order = _context.Orders.Find(id);
            return order;
        }

        public void saveOrder()
        {
            _context.SaveChanges();
        }
    }
}
