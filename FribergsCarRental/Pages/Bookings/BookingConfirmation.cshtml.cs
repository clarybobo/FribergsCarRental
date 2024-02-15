using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FribergsCarRental.Data;
using FribergsCarRental.Data.Models;

namespace FribergsCarRental.Pages.Bookings
{
    namespace FribergsCarRental.Pages.Bookings
    {
        public class BookingConfirmationModel : PageModel
        {
            private readonly IBooking bookingRepository;

            public BookingConfirmationModel(IBooking bookingRepository)
            {
                this.bookingRepository = bookingRepository;
            }

            public Booking Booking { get; set; }


            public async Task<IActionResult> OnGetAsync(int id)
            {
                // Fetch the booking details from the repository based on the bookingId
                Booking = await bookingRepository.GetBookingByIdAsync(id);

                // Check if the booking exists
                if (Booking == null)
                {
                    return NotFound();
                }

                return Page();
            }
        }
    }
}
