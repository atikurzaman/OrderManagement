using Microsoft.EntityFrameworkCore;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Infrastructure.Persistence.Repositories
{
    public class SubElementRepository : ISubElementRepository
    {
        private readonly OrderDbContext _context;

        public SubElementRepository(OrderDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SubElement>> GetSubElementsAsync()
        {
            return await _context.SubElements.AsNoTracking().ToListAsync();
        }

        public async Task<SubElement> GetSubElementByIdAsync(int id)
        {
            return await _context.SubElements.FindAsync(id);
        }        

        public async Task<int> CreateSubElementAsync(SubElement subElement)
        {
            await _context.SubElements.AddAsync(subElement);
            return await _context.SaveChangesAsync();            
        }

        public async Task<int> UpdateSubElementAsync(SubElement subElement)
        {
            _context.Entry(subElement).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteSubElementAsync(SubElement subElement)
        {
            _context.SubElements.Remove(subElement);
            return await _context.SaveChangesAsync();
        }        
    }
}
