namespace OrderManagement.Application.Services
{
    public interface IOrderService
    {
        Task<BaseCommandResponse> CreateOrderAsync(OrderForCreateDto orderForCreateDto);
        Task<BaseCommandResponse> DeleteOrderAsync(int id);
        Task<OrderForListDto> GetOrderByIdAsync(int id);
        Task<List<OrderForListDto>> GetOrdersAsync();
        Task<BaseCommandResponse> UpdateOrderAsync(OrderForUpdateDto orderForUpdateDto);
    }
}