using System.ComponentModel.DataAnnotations;

namespace OrderManagement.BlazorApp.Models
{
    public class SubElement
    {
        public int Element { get; set; }

        [Required]
        [StringLength(256, ErrorMessage = "Type must not exceed 256 characters")]
        public string Type { get; set; } = String.Empty;

        public float Width { get; set; }

        public float Height { get; set; }

        public int WindowId { get; set; }
    }

}
