﻿using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repositories
{
    public interface IProductRepository
    {
        void addProduct(Product product);
        void deleteProduct(Product product);
        void editProduct(Product product);
        List<Product> getAll();
        Product getProductById(int id);
        void saveProduct();

    }
}
