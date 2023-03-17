namespace OrderManagement.Application.Services
{
    public interface ISubElementService
    {   
        Task<SubElementForListDto> GetSubElementByIdAsync(int id);
        
        Task<List<SubElementForListDto>> GetSubElementsAsync();

        Task<BaseCommandResponse> CreateSubElementAsync(SubElementForCreateDto subElementForCreateDto);

        Task<BaseCommandResponse> UpdateSubElementAsync(SubElementForUpdateDto subElementForUpdateDto);

        Task<BaseCommandResponse> DeleteSubElementAsync(int id);

    }
}