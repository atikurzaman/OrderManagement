using Microsoft.EntityFrameworkCore;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Infrastructure.Persistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDbContext _context;

        public OrderRepository(OrderDbContext context)
        {
            _context = context;
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _context.Orders.Include(w => w.Windows).ThenInclude(s => s.SubElements).FirstOrDefaultAsync(o => o.Id == id); ;
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return await _context.Orders.AsNoTracking().ToListAsync();
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<int> UpdateOrderAsync(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;

            foreach (var window in order.Windows)
            {
                if (window.Id != 0)
                {
                    _context.Entry(window).State = EntityState.Modified;
                }
                else
                {
                    _context.Entry(window).State = EntityState.Added;
                }

                foreach (var subElement in window.SubElements)
                {
                    if (subElement.Id != 0)
                    {
                        _context.Entry(subElement).State = EntityState.Modified;
                    }
                    else
                    {
                        _context.Entry(subElement).State = EntityState.Added;
                    }

                    var idsOfSubElements = window.SubElements.Select(w => w.Id).ToList();
                    var subElementsToDelete = await _context.SubElements.Where(w => !idsOfSubElements.Contains(w.Id) && w.WindowId == window.Id).ToListAsync();
                    _context.RemoveRange(subElementsToDelete);
                }
            }

            var idsOfWindows = order.Windows.Select(w => w.Id).ToList();
            var windowsToDelete = await _context.Windows.Where(w => !idsOfWindows.Contains(w.Id) && w.OrderId == order.Id).ToListAsync();
            _context.RemoveRange(windowsToDelete);

            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteOrderAsync(Order order)
        {
            _context.Orders.Remove(order);
            return await _context.SaveChangesAsync();
        }
    }
}
