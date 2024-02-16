using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FribergsCarRental.Data;
using FribergsCarRental.Data.Models;
using Microsoft.CodeAnalysis.Options;
using Microsoft.AspNetCore.Http;
using FribergsCarRental.Pages.Users;

namespace FribergsCarRental.Pages.Bookings
{

    namespace FribergsCarRental.Pages.Bookings
    {
        public class BookingIndexModel : PageModel
        {
            private readonly IBooking bookingRepository;

            public BookingIndexModel(IBooking bookingRepository)
            {
                this.bookingRepository = bookingRepository;
            }


            public Booking Booking { get; set; } = default!;
            public int TheUserId { get; set; }

            public async Task OnGetAsync(int? id)
            {

                Booking = (await bookingRepository.GetBookingByIdAsync(id));
                  
            }

            public async Task<IActionResult> OnPost(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                await bookingRepository.DeleteBookingAsync(id);

                return RedirectToPage("/Users/AdminPage");
            }

  
        }
    }
}