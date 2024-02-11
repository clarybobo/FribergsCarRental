using System.ComponentModel.DataAnnotations;

namespace FribergsCarRental.Data.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        [Display(Name ="Bil")]
        public Car Car { get; set; }
        [Display(Name = "Hyrd av")]
        public TheUser TheUser { get; set; }

        [Display(Name = "Upphämtning")]
        [DataType(DataType.Date)]
        
        public DateTime StartDate { get; set; }
        [Display(Name = "Återlämning")]

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        //public int Price { get; set; }
    }
}
