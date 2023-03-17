namespace OrderManagement.Application.Services
{
    public interface IWindowService
    {
        Task<BaseCommandResponse> CreateWindowAsync(WindowForCreateDto windowForCreateDto);
        Task<BaseCommandResponse> DeleteWindowAsync(int id);
        Task<WindowForListDto> GetWindowByIdAsync(int id);
        Task<List<WindowForListDto>> GetWindowsAsync();
        Task<BaseCommandResponse> UpdateWindowAsync(WindowForUpdateDto windowForUpdateDto);
    }
}