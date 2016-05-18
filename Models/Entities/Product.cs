using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Product
    {
        public int productId { get; set; }
        public string name { get; set; }
        public double priceRetail { get; set; }
        public double priceWholesale { get; set; }
        public string description { get; set; }
        public string photoPath { get; set; }

        public virtual ICollection<LineProduct> lineproducts { get; set; }
    }
}
