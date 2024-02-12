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
            //private readonly IUser userRepository;
            //private readonly ICar carRepository;

            public BookingIndexModel(IBooking bookingRepository/*, IUser userRepository, ICar carRepository*/)
            {
                this.bookingRepository = bookingRepository;
                //this.userRepository = userRepository;
                //this.carRepository = carRepository;
            }

            public IList<Booking> Booking { get; set; } = default!;
            [BindProperty]
            public int BookingId { get; set; }


            public async Task OnGetAsync()
            {
                Booking = (await bookingRepository.GetAllBookingAsync()).ToList();
            }

            public async Task<IActionResult> OnGetDeleteAsync(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                await bookingRepository.DeleteBookingAsync(id);
                return RedirectToPage();
            }



        }
    }
}