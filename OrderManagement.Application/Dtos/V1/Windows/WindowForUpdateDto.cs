using OrderManagement.Application.Dtos.V1.Common;

namespace OrderManagement.Application.Dtos.V1.Windows
{
    public class WindowForUpdateDto:BaseEntityDto
    {
        public string Name { get; set; }

        public int QuantityOfWindows { get; set; }

        public int TotalSubElements { get; set; }

        public int OrderId { get; set; }
    }
}
