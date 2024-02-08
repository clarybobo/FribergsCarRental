namespace FribergsCarRental.Data.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public Car Car { get; set; }
        public TheUser TheUser { get; set; }
        //public Customer Customer { get; set; }
        //public User Customer { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int Price { get; set; }
    }
}
