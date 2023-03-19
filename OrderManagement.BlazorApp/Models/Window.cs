using System.ComponentModel.DataAnnotations;

namespace OrderManagement.BlazorApp.Models
{
    public class Window
    {
        [Required]
        [StringLength(256, ErrorMessage = "Name must not exceed 256 characters.")]
        public string Name { get; set; } = String.Empty;

        [Required]
        [Range(0, 1000, ErrorMessage = "Quantity of windows must be between 0 and 1000.")]
        public int QuantityOfWindows { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "Total sub elements must be between 0 and 100.")]
        public int TotalSubElements { get; set; }

        [Required]
        public int OrderId { get; set; }

        [ValidateComplexType]
        public List<SubElement> SubElements { get; set; } = new List<SubElement>();
    }
}
