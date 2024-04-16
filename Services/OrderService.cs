using Microsoft.Identity.Client;
using System.Runtime.CompilerServices;
using Cake_palace.Exceptions;
using Cake_palace.models;
using Cake_palace.Repository;

namespace Cake_palace.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;
        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<Order> DeleteOrder(int id)
        {
            var ord = await _repository.DeleteOrder(id);
            if (ord != null)
            {
                throw new OrderNotFoundException("Order with this id not found");
            }
            return ord;

        }

        public async Task<Order> EditOrder(int id, Order order)
        {
            var ord = await _repository.EditOrder(id,order);
            if(ord==null)
            {
                throw new OrderNotFoundException("Order with this idnot found");
            }
            return ord;
        }

        public async Task<Order> GetOrder(int id)
        {
            var order = await _repository.GetOrder(id);
            if(order == null)
            {
                throw new OrderNotFoundException("Order with this id not found");
            }
            return order;
        }

        public async Task<int> GetOrderCount()
        {
            return await _repository.GetOrderCount();
        }

        public async Task<List<Order>> GetOrders()
        {
            return await _repository.GetOrders();
        }

        public async Task<Order> PlaceOrder(Order order)
        {
            return await _repository.PlaceOrder(order);
        }
    }
}
