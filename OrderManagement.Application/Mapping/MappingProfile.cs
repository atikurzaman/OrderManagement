namespace OrderManagement.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SubElement, SubElementForListDto>().ReverseMap();
            CreateMap<SubElement, SubElementForCreateDto>().ReverseMap();
            CreateMap<SubElement, SubElementForUpdateDto>().ReverseMap();            
        }
    }
}
