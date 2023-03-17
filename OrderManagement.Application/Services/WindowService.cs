
namespace OrderManagement.Application.Services
{
    public class WindowService : IWindowService
    {
        private readonly IMapper _mapper;
        private readonly IWindowRepository _windowRepository;

        public WindowService(IMapper mapper, IWindowRepository windowRepository)
        {
            _mapper = mapper;
            _windowRepository = windowRepository;
        }

        public async Task<List<WindowForListDto>> GetWindowsAsync()
        {
            var windowsFromRepo = await _windowRepository.GetWindowsAsync();
            var windowsToReturn = _mapper.Map<List<WindowForListDto>>(windowsFromRepo);
            return windowsToReturn;
        }

        public async Task<WindowForListDto> GetWindowByIdAsync(int id)
        {
            var windowFromRepo = await _windowRepository.GetWindowByIdAsync(id);
            var windowToReturn = _mapper.Map<WindowForListDto>(windowFromRepo);
            return windowToReturn;
        }

        public async Task<BaseCommandResponse> CreateWindowAsync(WindowForCreateDto windowForCreateDto)
        {
            var response = new BaseCommandResponse();
            var validator = new WindowForCreateDtoValidator();
            var validationResult = await validator.ValidateAsync(windowForCreateDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }

            var windowToCreate = _mapper.Map<Window>(windowForCreateDto);
            var createdWindow = await _windowRepository.CreateWindowAsync(windowToCreate);
            response.Success = true;
            response.Message = "Creation Successful";
            return response;
        }

        public async Task<BaseCommandResponse> UpdateWindowAsync(WindowForUpdateDto windowForUpdateDto)
        {
            var response = new BaseCommandResponse();
            var validator = new WindowForUpdateDtoValidator();
            var validationResult = await validator.ValidateAsync(windowForUpdateDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }

            var windowToUpdate = _mapper.Map<Window>(windowForUpdateDto);
            var result = await _windowRepository.UpdateWindowAsync(windowToUpdate);
            response.Success = true;
            response.Message = "Creation Successful";
            return response;
        }

        public async Task<BaseCommandResponse> DeleteWindowAsync(int id)
        {
            var response = new BaseCommandResponse();
            var windowToDelete = await _windowRepository.GetWindowByIdAsync(id);

            if (windowToDelete == null)
            {
                throw new NotFoundException(nameof(Window), id);
            }

            await _windowRepository.DeleteWindowAsync(windowToDelete);
            response.Success = true;
            response.Message = "Deleting Successful";
            return response;
        }
    }
}
