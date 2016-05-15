using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class LineProduct
    {
        public int lineProductId { get; set; }
        public int orderId { get; set; }
        public int productId { get; set; }

        public virtual Order order { get; set; }
        public virtual Product product { get; set; }
    }
}
