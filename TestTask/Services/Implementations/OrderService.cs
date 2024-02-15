using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Enums;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _db;
        public OrderService(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Order> GetOrder() //done
        {  
            var order = await _db.Orders.AsNoTracking().ToListAsync();
            var maxQuantity = order.OrderByDescending(p => p.Price).ThenByDescending(q=>q.Quantity).FirstOrDefault();
            return maxQuantity;
        }

        public async Task<List<Order>> GetOrders() //done
        {
            var orders = await _db.Orders.ToListAsync();
            var ordersOver10 = orders.Where(q => q.Quantity > 10).ToList();
            return ordersOver10;
        }
    }
}
