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
            _context.Orders.Add(order);
            saveOrder();
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
