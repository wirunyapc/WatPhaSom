using Models.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModel
{
    public class ShoppingCartViewModel
    {
        [Key]
        public List<Cart> CartItems { get; set; }
        public Product item { get; set; }
        public decimal CartTotal { get; set; }
    }
}