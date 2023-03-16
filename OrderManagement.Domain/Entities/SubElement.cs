namespace OrderManagement.Domain.Entities
{
    public class SubElement : BaseEntity
    {
        public int Element { get; set; }

        public string Type { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public int WindowId { get; set; }

        public Window Window { get; set; }
    }
}