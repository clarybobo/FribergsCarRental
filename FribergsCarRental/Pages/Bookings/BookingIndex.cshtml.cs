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

            public IList<Booking> Bookings { get; set; } = default!;

            [BindProperty]
            public Booking Booking { get; set; } = default!;
            public int BookingId { get; set; }

            public async Task OnGetAsync()
            {
                Bookings = (await bookingRepository.GetAllBookingAsync()).ToList();                
            }
               
            public async Task<IActionResult> OnPostDeleteAsync(int id)
            {
                BookingId = id;
                await bookingRepository.DeleteBookingAsync(BookingId);
                return RedirectToPage("/Bookings/BookingIndex");
            }

        }
    }
}