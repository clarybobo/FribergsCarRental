using FribergsCarRental.Data.Models;

namespace FribergsCarRental.Data
{
    public interface IBooking
    {
        Task<IEnumerable<Booking>> GetAllBookingAsync();
        Task<Booking> GetBookingByIdAsync(int id);
        //Task<Booking> AddBookingAsync(Booking booking);
        //Task<Booking> EditBookingAsync(Booking booking, int id);
        Task DeleteBookingAsync(int id);
    }
}
