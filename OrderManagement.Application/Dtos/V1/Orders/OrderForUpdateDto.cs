using OrderManagement.Application.Dtos.V1.Common;

namespace OrderManagement.Application.Dtos.V1.Orders
{
    public class OrderForUpdateDto:BaseEntityDto
    {
        public string Name { get; set; }

        public string State { get; set; }
    }
}
