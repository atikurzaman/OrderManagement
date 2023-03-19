using System.ComponentModel.DataAnnotations;

namespace OrderManagement.BlazorApp.Models
{
    public class Window
    {
        [Required]
        [StringLength(256, ErrorMessage = "Name must not exceed 256 characters")]
        public string Name { get; set; } = String.Empty;

        [Required]
        public int QuantityOfWindows { get; set; }

        [Required]
        public int TotalSubElements { get; set; }

        [Required]
        public int OrderId { get; set; }
        
        public List<SubElement> SubElements { get; set; } = new List<SubElement>();
    }
}
