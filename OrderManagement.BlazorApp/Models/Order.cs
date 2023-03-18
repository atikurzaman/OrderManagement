namespace OrderManagement.BlazorApp.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string Name { get; set; } = String.Empty;

        public string State { get; set; } = String.Empty;
    }
}
