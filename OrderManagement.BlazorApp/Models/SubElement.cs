using System.ComponentModel.DataAnnotations;

namespace OrderManagement.BlazorApp.Models
{
    public class SubElement
    {
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity of windows must be between {1} and {2}.")]
        public int Element { get; set; }

        [Required]
        [StringLength(256, ErrorMessage = "Type must not exceed 256 characters")]
        public string Type { get; set; } = String.Empty;

        [Range(0, int.MaxValue, ErrorMessage = "Width must be between {1} and {2}.")]
        public int Width { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Height of windows must be between {1} and {2}.")]
        public int Height { get; set; }

        public int WindowId { get; set; }
    }

}
