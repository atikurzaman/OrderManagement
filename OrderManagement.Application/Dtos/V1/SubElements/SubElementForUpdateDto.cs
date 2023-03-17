using OrderManagement.Application.Dtos.V1.Common;

namespace OrderManagement.Application.Dtos.V1.SubElements
{
    public class SubElementForUpdateDto: BaseEntityDto
    {
        public int Element { get; set; }

        public string Type { get; set; }

        public float Width { get; set; }

        public float Height { get; set; }
    }
}
