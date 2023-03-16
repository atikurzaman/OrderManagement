namespace OrderManagement.Domain.Entities
{
    public class Order : BaseEntity
    {
        public string Name { get; set; }

        public string State { get; set; }

        public ICollection<Window> Windows { get; set; }
    }
}
