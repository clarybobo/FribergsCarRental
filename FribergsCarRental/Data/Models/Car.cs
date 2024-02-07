using System.ComponentModel.DataAnnotations;

namespace FribergsCarRental.Data.Models
{
    public class Car
    {
        [Required]
        public int CarId { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string PictureURL { get; set; }
    }
}
