using OrderManagement.Domain.Entities;

namespace OrderManagement.Infrastructure.Persistence.Repositories
{
    public interface ISubElementRepository
    {
        Task<IEnumerable<SubElement>> GetSubElementsAsync();

        Task<SubElement> GetSubElementByIdAsync(int id);

        Task<int> CreateSubElementAsync(SubElement subElement);

        Task<int> UpdateSubElementAsync(SubElement subElement);

        Task<int> DeleteSubElementAsync(SubElement subElement);               
        
    }
}