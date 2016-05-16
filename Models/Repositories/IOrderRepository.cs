﻿using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repositories
{
    interface IOrderRepository
    {
        void addOrder(Order order);
        void deleteOrder(string id);
        void editOrder(Order order);
        //List<Product> getAll();
        Order getOrderById(string id);
        void saveOrder();
    }
}