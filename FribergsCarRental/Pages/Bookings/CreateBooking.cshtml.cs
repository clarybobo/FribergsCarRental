using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FribergsCarRental.Data;
using FribergsCarRental.Data.Models;
using System.Security.Permissions;

namespace FribergsCarRental.Pages.Bookings
{
    namespace FribergsCarRental.Pages.Bookings
    {
        public class CreateBookingModel : PageModel
        {

            private readonly IBooking bookingRepository;
            private readonly ICar carRepository;
            private readonly IUser userRepository;
            private readonly IHttpContextAccessor httpContextAccessor;

            public CreateBookingModel(IBooking bookingRepository, ICar carRepository, IUser userRepository, IHttpContextAccessor httpContextAccessor)
            {
                this.bookingRepository = bookingRepository;
                this.carRepository = carRepository;
                this.userRepository = userRepository;
                this.httpContextAccessor = httpContextAccessor;
            }


            [BindProperty]
            public Booking Booking { get; set; } = default!;
            public Car Car { get; set; }
            public int CarId { get; set; }

            public async Task<IActionResult> OnGet(int id)
            {
                CarId = id;
                Car = await carRepository.GetCarByIdAsync(CarId);
                return Page();
            }


            // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD

            public async Task<IActionResult> OnPostAsync(int id)
            {                             
                CarId = id;
                Car = await carRepository.GetCarByIdAsync(CarId);
                Booking.Car = Car;

                if (int.TryParse(httpContextAccessor.HttpContext.Request.Cookies["customerCookie"], out int userId)) //Användar-id konverteras tillbaka till int
                {
                    var loggedInUser = await userRepository.GetUserByIdAsync(userId);
                    Booking.TheUser = loggedInUser;
                }

                var booking = await bookingRepository.AddBookingAsync(Booking);
                Booking = booking;

                return RedirectToPage("/Bookings/BookingConfirmation", new { id = Booking.BookingId });
            }
        }
    }
}