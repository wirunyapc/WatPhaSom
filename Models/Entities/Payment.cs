using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities
{
    public class Payment
    {
        [ForeignKey("order")]
        public int paymentId { get; set; }
        public Boolean isPay { get; set; }
        public string paymentMethod { get; set; }
        public string slipPath { get; set; }

        public virtual Order order { get; set; }

    }
}
