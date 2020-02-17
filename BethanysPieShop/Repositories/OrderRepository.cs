using System;
using System.Collections.Generic;
using BethanysPieShop.Models;

namespace BethanysPieShop.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ShoppingCart _shoppingCart;

        public OrderRepository(AppDbContext dbContext, ShoppingCart shoppingCart)
        {
            _dbContext = dbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

            order.OrderDetails = new List<OrderDetail>();
            //adding the order with its details

            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = shoppingCartItem.Amount,
                    PieId = shoppingCartItem.Pie.PieId,
                    Price = shoppingCartItem.Pie.Price
                };

                order.OrderDetails.Add(orderDetail);
            }

            _dbContext.Orders.Add(order);

            _dbContext.SaveChanges();
        }
    }
}
