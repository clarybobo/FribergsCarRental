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
        public class CustomersBookingIndexModel : PageModel
        {
            private readonly IBooking bookingRepository;
        

            public CustomersBookingIndexModel(IBooking bookingRepository)
            {
                this.bookingRepository = bookingRepository;          
            }

            public IList<Booking> Booking { get; set; } = default!;      

            public async Task OnGetAsync()
            {
                Booking = (await bookingRepository.GetAllBookingAsync()).ToList();
                //ÄNDRA TILL METOD SOM HÄMTAR BOOKINGS PÅ KUND ID 
            }

            public async Task<IActionResult> OnPostDeleteAsync(int? id)
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

    
