using System.ComponentModel.DataAnnotations;

namespace FribergsCarRental.Data.Models
{
    public class Car
    {
        [Required]
        public int CarId { get; set; }
        [Required]
        [Display(Name = "Tillverkare")]
        public string Brand { get; set; }
        [Required]
        [Display(Name = "Modell")]
        public string Model { get; set; }
        [Required]
        [Display(Name = "Bildlänk")]
        public string PictureURL { get; set; }
    }
}
