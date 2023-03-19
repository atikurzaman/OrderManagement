using System.ComponentModel.DataAnnotations;

namespace OrderManagement.BlazorApp.Models
{
    public class SubElement
    {
        [Required]
        [Range(0, 1000, ErrorMessage = "Quantity of windows must be between 0 and 1000.")]
        public int Element { get; set; }

        [Required]
        [StringLength(256, ErrorMessage = "Type must not exceed 256 characters")]
        public string Type { get; set; } = String.Empty;

        [Range(0, 1000, ErrorMessage = "Width must be between 0 and 1000.")]
        public float Width { get; set; }

        [Range(0, 1000, ErrorMessage = "Height of windows must be between 0 and 1000.")]
        public float Height { get; set; }

        public int WindowId { get; set; }
    }

}
