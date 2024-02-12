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
            //private readonly IUser userRepository;
            //private readonly ICar carRepository;

            public CustomersBookingIndexModel(IBooking bookingRepository /*IUser userRepository, ICar carRepository*/)
            {
                this.bookingRepository = bookingRepository;
                //this.userRepository = userRepository;
                //this.carRepository = carRepository;
            }

            public IList<Booking> Booking { get; set; } = default!;
            //public TheUser TheUser { get; set; }
            //public Car Car { get; set; }


            public async Task OnGetAsync()
            {
                Booking = (await bookingRepository.GetAllBookingAsync()).ToList();

            }
        }
    }
}

    
