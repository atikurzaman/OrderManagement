using OrderManagement.Application.Dtos.V1.Common;

namespace OrderManagement.Application.Dtos.V1.Order
{
    public class OrderForUpdateDto:BaseEntityDto
    {
        public string Name { get; set; }

        public string State { get; set; }

        public List<WindowForUpdateDto> Windows { get; set; }
    }
}
