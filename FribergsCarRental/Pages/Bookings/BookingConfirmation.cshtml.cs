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

            [BindProperty]
            public Booking Booking { get; set; }

    
            public async Task<IActionResult> OnGetAsync(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var booking = await bookingRepository.GetBookingByIdAsync(id);

                if (booking == null)
                {
                    return NotFound();
                }
                Booking = booking;
                return Page();
            }

            public async Task<IActionResult> OnPostAsync()
            {
               
                if (Booking == null)
                {
                    return NotFound();
                }
                               
                return RedirectToPage("/Bookings/CustomersBookingIndex");
            }
        }
    }
}
