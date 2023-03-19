using System.ComponentModel.DataAnnotations;

namespace OrderManagement.BlazorApp.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        [StringLength(256, ErrorMessage = "Name must not exceed 256 characters")]
        public string Name { get; set; } = String.Empty;

        [Required]
        [StringLength(256, ErrorMessage = "State must not exceed 256 characters")]
        public string State { get; set; } = String.Empty;

        public List<Window>? Windows { get; set; } = new List<Window>();
    }
}
