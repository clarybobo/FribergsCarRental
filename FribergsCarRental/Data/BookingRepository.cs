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

        public async Task DeleteBookingsAsync(int id)
        {
            var existingBooking = await applicationDbContext.Bookings.FindAsync(id);
            if (existingBooking != null)
            {
                applicationDbContext.Bookings.Remove(existingBooking);
                await applicationDbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Booking>> GetAllBookingAsync()
        {
            return await applicationDbContext.Bookings.OrderBy(c => c.BookingId).ToListAsync();
        }

        //public async Task DeleteBookingAsync(int id)
        //{
        //    var existingBooking = await applicationDbContext.Bookings.FindAsync(id);
        //    if (existingBooking != null)
        //    {
        //        applicationDbContext.Bookings.Remove(existingBooking);
        //        await applicationDbContext.SaveChangesAsync();
        //    }
        //}


        //public async Task<IEnumerable<Booking>> GetAllBookingAsync()
        //{
        //    return await applicationDbContext.Bookings.OrderBy(c => c.BookingId).ToListAsync();
        //}


        //public async Task<Booking> GetBookingByIdAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<Booking> AddBookingAsync(Booking booking)
        //{
        //    applicationDbContext.Bookings.Add(booking);
        //    await applicationDbContext.SaveChangesAsync();
        //    return booking;
        //}

        //public async Task<Booking> EditBookingAsync(Booking booking, int id)
        //{
        //    throw new NotImplementedException();
        //}

    }
}
