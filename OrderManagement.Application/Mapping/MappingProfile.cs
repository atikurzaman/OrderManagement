namespace OrderManagement.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderForListDto>().ReverseMap();
            CreateMap<Order, OrderForCreateDto>().ReverseMap();
            CreateMap<Order, OrderForUpdateDto>().ReverseMap();
            CreateMap<Window, WindowForListDto>().ReverseMap();
            CreateMap<Window, WindowForCreateDto>().ReverseMap();
            CreateMap<Window, WindowForUpdateDto>().ReverseMap();
            CreateMap<SubElement, SubElementForListDto>().ReverseMap();
            CreateMap<SubElement, SubElementForCreateDto>().ReverseMap();
            CreateMap<SubElement, SubElementForUpdateDto>().ReverseMap();         
        }
    }
}
