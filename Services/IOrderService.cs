﻿using Cake_palace.models;

namespace Cake_palace.Services
{
    public interface IOrderService
    {
        Task<Order> PlaceOrder(Order order);
        Task<List<Order>> GetOrders();
        Task<Order> GetOrder(int id);
        Task<Order> EditOrder(int id, Order order);
        Task<Order> DeleteOrder(int id);
        Task<int> GetOrderCount();
    }
}
