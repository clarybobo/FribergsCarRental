﻿using FribergsCarRental.Data.Models;
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

        public async Task<IEnumerable<Booking>> GetLoggedInCustomersBooking(int? id)
        {
            return await applicationDbContext.Bookings
           .Include(b => b.Car)
              .Include(b => b.TheUser)
              .Where(b => b.TheUser.TheUserId == id)
                .OrderBy(c => c.StartDate).ToListAsync();
        }

        public async Task<Booking> AddBookingAsync(Booking booking)
        {
            applicationDbContext.Bookings.Add(booking);
            await applicationDbContext.SaveChangesAsync();
            return booking;
        }

    }
}
