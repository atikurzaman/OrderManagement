namespace OrderManagement.Application.Dtos.V1.Order
{
    public class OrderForCreateDto
    {
        public string Name { get; set; }

        public string State { get; set; }

        public List<WindowForCreateDto> Windows { get; set; }
    }
}
