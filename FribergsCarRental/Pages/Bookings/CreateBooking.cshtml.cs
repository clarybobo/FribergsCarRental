using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FribergsCarRental.Data;
using FribergsCarRental.Data.Models;

namespace FribergsCarRental.Pages.Bookings
{
    public class CreateBookingModel : PageModel
    {

        private readonly IBooking bookingRepository;

        public CreateBookingModel(IBooking bookingRepository)
        {
            this.bookingRepository = bookingRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Booking Booking { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
  
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || Booking == null)
            {
                return Page();
            }
            var booking = await bookingRepository.AddBookingAsync(Booking);
            Booking = booking;

            return RedirectToPage("/Bookings/BookingIndex");
        }
    }
}
