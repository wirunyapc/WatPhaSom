using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class ProductViewModels
    {
        public class ProductViewModel
        {
            public int productId { get; set; }
            public string name { get; set; }
            public double price { get; set; }
            public string description { get; set; }
            public string photoPath { get; set; }

            public ProductViewModel GetObject(Product p, string priceType)
            {

                return priceType.Equals("Wholesale") ?
                    new ProductViewModel { productId = p.productId, name = p.name, price = p.priceWholesale, description = p.description, photoPath = p.photoPath }
                    : new ProductViewModel { productId = p.productId, name = p.name, price = p.priceRetail, description = p.description, photoPath = p.photoPath };
            }
        }
    }
}
