using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entities;

namespace Models.Entities
{
    public class Review
    {
        public Review() { }
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }

        public int ProductId { get; set; }

        //[ForeignKey("productId")]
        //public virtual Product Product { get; set; }
    }


}
