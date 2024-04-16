using Microsoft.EntityFrameworkCore;
using Cake_palace.Data;
using Cake_palace.models;

namespace Cake_palace.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly Cake_palaceContext _context;
        public OrderRepository(Cake_palaceContext context)
        {
            _context = context;
        }

        public async Task<Order> DeleteOrder(int id)
        {
            var ord = await _context.Orders.FindAsync(id);
            if (ord != null)
            {
                _context.Orders.Remove(ord);
                _context.SaveChangesAsync();
            }
            return ord;

        }

        public async Task<Order> EditOrder(int id, Order order)
        {
            var ord = await _context.Orders.FindAsync(id);
            if(ord != null)
            {
                ord.OrderDetail = order.OrderDetail;
                ord.OrderDate = order.OrderDate;
                ord.Status = order.Status;
                ord.CartId = order.CartId;
            }
            return ord;
        }

        public async Task<Order> GetOrder(int id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task<List<Order>> GetOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> PlaceOrder(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<int> GetOrderCount()
        {
            return await _context.Orders.CountAsync();
        }
    }
}
