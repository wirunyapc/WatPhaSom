using Models.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace Models.Entities
{
        public class Cart
        {
            [Key]
            public int ID { get; set; }
            public string CartId { get; set; }
            public int productId { get; set; }
            public int Count { get; set; }
            public System.DateTime DateCreated { get; set; }
            public virtual Product product { get; set; }
        }
    }
