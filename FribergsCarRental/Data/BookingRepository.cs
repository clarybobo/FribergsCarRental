using FribergsCarRental.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FribergsCarRental.Data
{
    public class BookingRepository : IBooking
    {
        private readonly ApplicationDbContext applicationDbContext;

        public BookingRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task DeleteBookingAsync(int? id)
        {
            var existingBooking = await applicationDbContext.Bookings.FirstOrDefaultAsync(b => b.BookingId == id);
            if (existingBooking != null)
            {
                applicationDbContext.Bookings.Remove(existingBooking);
                await applicationDbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Booking>> GetAllBookingAsync()
        {
            return await applicationDbContext.Bookings
             .Include(b => b.Car)
                .Include(b => b.TheUser)
                  .OrderBy(c => c.BookingId).ToListAsync();
        }


        public async Task<Booking> GetBookingByIdAsync(int? id)
        {
            var booking = await applicationDbContext.Bookings
                .Include(b => b.Car)
                .Include(b => b.TheUser)
                .FirstOrDefaultAsync(c => c.BookingId == id);
            return booking;
        }

        //skapa en metod där som hämtar alla bokningar för en given kund där kundId kan tas som inparameter,
        //sedan kan du använda den när en kund vill se sina bokingar och skicka med den inloggade kundens id som argument till metodanropet.
        public async Task<Booking> GetLoggedInCustomersBooking(int? id)
        {
            return await applicationDbContext.Bookings
           .Include(b => b.Car)
              .Include(b => b.TheUser)
                .OrderBy(c => c.BookingId).ToListAsync();
        }

        public async Task<Booking> AddBookingAsync(Booking booking)
        {
            applicationDbContext.Bookings.Add(booking);
            await applicationDbContext.SaveChangesAsync();
            return booking;
        }

    }
}
