using System.ComponentModel.DataAnnotations;

namespace VillaWebApp.Models
{
    public class Villa
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is required")]
        [MaxLength(30)]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Details is required")]
        [StringLength(200, MinimumLength = 6)]
        public string Details { get; set; }

        [Required(ErrorMessage = "Rate is required")]
        public double Rate { get; set; }

        [Required(ErrorMessage = "ImageUrl is required")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Amenities is required")]
        public string Amenity { get; set; }

        [Required(ErrorMessage = "Occupancy is required")]
        public int Occupancy { get; set; }

        [Required(ErrorMessage = "Sqft is required")]
        public int Sqft { get; set; }
    }
}
