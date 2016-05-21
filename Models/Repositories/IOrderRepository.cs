using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repositories
{
    public interface IOrderRepository
    {
        void addOrder(Order order);
        void deleteOrder(string id);
        void editOrder(Order order);
        List<Order> getAll();
        Order getOrderById(int id);
        void saveOrder();
    }
}
