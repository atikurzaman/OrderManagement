using OrderManagement.Domain.Entities;

namespace OrderManagement.Infrastructure.Persistence.Repositories
{
    public interface IWindowRepository
    {
        Task<Window> CreateWindowAsync(Window window);
        Task<int> DeleteWindowAsync(Window window);
        Task<Window> GetWindowByIdAsync(int id);
        Task<IEnumerable<Window>> GetWindowsAsync();
        Task<int> UpdateWindowAsync(Window window);
    }
}