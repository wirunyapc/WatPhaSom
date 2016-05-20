﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Payment
    {
        [Key]
        public String paymentId { get; set; }
        public String paymentMethod { get; set; }
    }
}
