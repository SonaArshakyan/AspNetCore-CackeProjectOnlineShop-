using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetCoreProjectExample.OnlineShop.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDBContext _appDBContext;
        private readonly ShoppingCart _shoppingCart;


        public OrderRepository( AppDBContext  appDBContext  , ShoppingCart shoppingCart)
        {
            _appDBContext = appDBContext;
            _shoppingCart = shoppingCart;
        }
        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
             _appDBContext.Orders.Add(order);
            _appDBContext.SaveChanges();
            var shoppingCartItems = _shoppingCart.ShoppingCartItems;
            foreach ( var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount= shoppingCartItem.Amount,
                    PieId = shoppingCartItem.Pie.PieId,
                    OrderId = order.OrderId,
                    Price = shoppingCartItem.Pie.Prices
                };
                _appDBContext.OrderDetails.Add(orderDetail);
                
            }
            _appDBContext.SaveChanges();
        }
    }
}
