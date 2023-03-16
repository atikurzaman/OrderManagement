using Microsoft.EntityFrameworkCore;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Infrastructure.Persistence.Repositories
{
    public class WindowRepository : IWindowRepository
    {
        private readonly OrderDbContext _context;

        public WindowRepository(OrderDbContext context)
        {
            _context = context;
        }

        public async Task<Window> GetWindowByIdAsync(int id)
        {
            return await _context.Windows.FindAsync(id);
        }

        public async Task<IEnumerable<Window>> GetWindowsAsync()
        {
            return await _context.Windows.AsNoTracking().ToListAsync();
        }

        public async Task<Window> CreateWindowAsync(Window window)
        {
            await _context.Windows.AddAsync(window);
            await _context.SaveChangesAsync();
            return window;
        }

        public async Task<int> UpdateWindowAsync(Window window)
        {
            _context.Entry(window).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteWindowAsync(Window window)
        {
            _context.Windows.Remove(window);
            return await _context.SaveChangesAsync();
        }
    }
}
