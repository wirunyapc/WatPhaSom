﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Models.Entities;
using System.Data.SqlClient;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Models.EF
{
    public class EFDbContext : DbContext

    {
        public EFDbContext() : base("EFDbContext")
        {

        } 
        public DbSet<Product> Products {get; set;}
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Review> Reviews { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
