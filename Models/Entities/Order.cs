using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Models.Entities
{
    public class Order
    {
        public Order() { }
        [Key]
        public int orderId { get; set; }
        public int customerId { get; set; }
        public int paymentId { get; set; }
        public int lineProductId { get; set; }
        public DateTime orderDate { get; set; }
        public Boolean isConfirm { get; set; }
        public string deliverAddress { get; set; }
        public double mountainCost { get; set; }
        public double toHomeCost { get; set; }
        public double totalPrice { get; set; }

   
     //   public virtual u customer { get; set; }
        public virtual ICollection<LineProduct> lineproducts { get; set; }
        public virtual Payment payment { get; set; }

    }
}
