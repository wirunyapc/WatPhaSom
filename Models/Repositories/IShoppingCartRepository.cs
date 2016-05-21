using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Models.Repositories
{
    public partial interface IShoppingCartRepository
    {
        ShoppingCartRepository GetCart(HttpContextBase context);
        int AddToCart(Product item);
        int AddToCart(Product item, int amount);
        void RemoveFromCart(int id);
        void EmptyCart();
        List<Cart> GetCartItems();
        int GetCount();
        decimal GetTotal(string role);
        string GetCartId(HttpContextBase context);
        void MigrateCart(string userName);
    }
}
