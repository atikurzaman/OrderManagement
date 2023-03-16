using OrderManagement.Domain.Entities;

namespace OrderManagement.Infrastructure.Persistence.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> CreateOrderAsync(Order order);
        Task<int> DeleteOrderAsync(Order order);
        Task<Order> GetOrderByIdAsync(int id);
        Task<IEnumerable<Order>> GetOrdersAsync();
        Task<int> UpdateOrderAsync(Order order);
    }
}