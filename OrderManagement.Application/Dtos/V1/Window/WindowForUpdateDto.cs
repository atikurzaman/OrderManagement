
namespace OrderManagement.Application.Dtos.V1.Window
{
    public class WindowForUpdateDto:BaseEntityDto
    {
        public string Name { get; set; }

        public int QuantityOfWindows { get; set; }

        public int TotalSubElements { get; set; }

        public int OrderId { get; set; }

        public List<SubElementForCreateDto> SubElements { get; set; }
    }
}
