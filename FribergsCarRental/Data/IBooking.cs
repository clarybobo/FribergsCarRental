using FribergsCarRental.Data.Models;

namespace FribergsCarRental.Data
{
    public interface IBooking
    {
        Task<IEnumerable<Booking>> GetAllBookingAsync();
        Task DeleteBookingsAsync(int id);

    


        //Task<Booking> GetBookingByIdAsync(int id);
        //Task<Booking> AddBookingAsync(Booking booking);
        //Task<Booking> EditBookingAsync(Booking booking, int id);
    }
}
