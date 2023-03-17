
namespace OrderManagement.Application.Services
{
    public class SubElementService : ISubElementService
    {
        private readonly IMapper _mapper;
        private readonly ISubElementRepository _subElementRepository;

        public SubElementService(IMapper mapper, ISubElementRepository subElementRepository)
        {
            _mapper = mapper;
            _subElementRepository = subElementRepository;
        }

        public async Task<List<SubElementForListDto>> GetSubElementsAsync()
        {
            var subElementsFromRepo = await _subElementRepository.GetSubElementsAsync();
            var subElemenstToReturn = _mapper.Map<List<SubElementForListDto>>(subElementsFromRepo);
            return subElemenstToReturn;
        }

        public async Task<SubElementForListDto> GetSubElementByIdAsync(int id)
        {
            var subElementFromRepo = await _subElementRepository.GetSubElementByIdAsync(id);
            var subElementToReturn = _mapper.Map<SubElementForListDto>(subElementFromRepo);
            return subElementToReturn;
        }

        public async Task<BaseCommandResponse> CreateSubElementAsync(SubElementForCreateDto subElementForCreateDto)
        {
            var response = new BaseCommandResponse();
            var validator = new SubElementForCreateDtoValidator();
            var validationResult = await validator.ValidateAsync(subElementForCreateDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }

            var subElementToCreate = _mapper.Map<SubElement>(subElementForCreateDto);
            var createdSubElement = await _subElementRepository.CreateSubElementAsync(subElementToCreate);
            response.Success = true;
            response.Message = "Creation Successful";
            return response;
        }

        public async Task<BaseCommandResponse> UpdateSubElementAsync(SubElementForUpdateDto subElementForUpdateDto)
        {
            var response = new BaseCommandResponse();
            var validator = new SubElementForUpdateDtoValidator();
            var validationResult = await validator.ValidateAsync(subElementForUpdateDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Updating Failed";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }

            var subElementToUpdate = _mapper.Map<SubElement>(subElementForUpdateDto);
            var result = await _subElementRepository.UpdateSubElementAsync(subElementToUpdate);
            response.Success = true;
            response.Message = "Updating Successful";
            return response;
        }

        public async Task<BaseCommandResponse> DeleteSubElementAsync(int id)
        {
            var response = new BaseCommandResponse();
            var subElementToDelete = await _subElementRepository.GetSubElementByIdAsync(id);

            if (subElementToDelete == null)
            {
                throw new NotFoundException(nameof(SubElement), id);
            }

            await _subElementRepository.DeleteSubElementAsync(subElementToDelete);
            response.Success = true;
            response.Message = "Deleting Successful";
            return response;
        }
    }
}
