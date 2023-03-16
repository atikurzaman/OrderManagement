using OrderManagement.Domain.Entities;

namespace OrderManagement.Infrastructure.Persistence.Repositories
{
    public interface ISubElementRepository
    {
        Task<SubElement> CreateSubElementAsync(SubElement subElement);
        Task<int> DeleteSubElementAsync(SubElement subElement);
        Task<SubElement> GetSubElementByIdAsync(int id);
        Task<IEnumerable<SubElement>> GetSubElementsAsync();
        Task<int> UpdateSubElementAsync(SubElement subElement);
    }
}