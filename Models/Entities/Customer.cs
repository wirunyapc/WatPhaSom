using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Customer
    {
        public Customer()
        {
            orders = new List<Order>();
        }

        public int customerId { get; set; }
        public string customerName { get; set; }
        public string customerSurname { get; set; }
        public string telephoneNo { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public int password { get; set; }
        public string customerType { get; set; }

        public virtual ICollection<Order> orders { get; set; }

    }
}
