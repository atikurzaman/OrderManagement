namespace OrderManagement.Domain.Entities
{
    public class Window : BaseEntity
    {
        public string Name { get; set; }

        public int QuantityOfWindows { get; set; }

        public int TotalSubElements { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }

        public ICollection<SubElement> SubElements { get; set; }

    }
}
