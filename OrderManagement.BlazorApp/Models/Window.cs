using System.ComponentModel.DataAnnotations;

namespace OrderManagement.BlazorApp.Models
{
    public class Window
    {
        [Required]
        [StringLength(256, ErrorMessage = "Name must not exceed 256 characters.")]
        public string Name { get; set; } = String.Empty;

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity of windows must be between {1} and {2}.")]
        public int QuantityOfWindows { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Total sub elements must be between {1} and {2}.")]
        public int TotalSubElements { get; set; }

        [Required]
        public int OrderId { get; set; }

        [ValidateComplexType]
        public List<SubElement> SubElements { get; set; } = new List<SubElement>();
    }
}
