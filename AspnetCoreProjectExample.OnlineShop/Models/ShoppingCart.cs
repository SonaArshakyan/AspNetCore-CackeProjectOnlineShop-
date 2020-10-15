using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetCoreProjectExample.OnlineShop.Models
{
    public class ShoppingCart
    {
        private readonly AppDBContext _appDBContext;

        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        private ShoppingCart( AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;
            var context = services.GetService<AppDBContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);
            return new ShoppingCart(context) { ShoppingCartId = cartId};
        }
        public void AddToCart(Pie pie , int amount) 
        {
            var shoppingCartItem =
                _appDBContext.ShoppingCartItems.SingleOrDefault( s => s.Pie.PieId == pie.PieId && s.ShoppingCartId == ShoppingCartId);
            if(shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Pie = pie,
                    Amount = amount
                };
                _appDBContext.ShoppingCartItems.Add(shoppingCartItem);

            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _appDBContext.SaveChanges();
        }
        public int RemoveFromCart(Pie pie)
        {
            var shoppingCartItem = _appDBContext.ShoppingCartItems.SingleOrDefault(s => s.Pie.PieId == pie.PieId && s.ShoppingCartId == ShoppingCartId);
            var localAmount = 0;
            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _appDBContext.ShoppingCartItems.Remove(shoppingCartItem);
                }               
            }
            _appDBContext.SaveChanges();
            return localAmount;
        }
        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return 
                ShoppingCartItems = 
                _appDBContext.ShoppingCartItems.Where(c=> c.ShoppingCartId == ShoppingCartId).Include(s=>s.Pie).ToList();
        }
        public void ClearCart()
        {
            var cartItems = _appDBContext.ShoppingCartItems.Where(cart => cart.ShoppingCartId == ShoppingCartId);
            _appDBContext.ShoppingCartItems.RemoveRange(cartItems);
            _appDBContext.SaveChanges();
        }
        public decimal GetShoppingCartTotal()
        {
            var total = _appDBContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId).Select(c => c.Pie.Prices * c.Amount).Sum();
            return total;
        }
    }
}
