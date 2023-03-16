namespace OrderManagement.Domain
{
    public class Window
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int QuantityOfWindows { get; set; }

        public int TotalSubElements { get; set; }

        public  ICollection<SubElement>? SubElements { get; set; }

    }
}
