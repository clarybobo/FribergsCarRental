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
            private readonly IUser userRepository;
            private readonly ICar carRepository;

            public BookingIndexModel(IBooking bookingRepository, IUser userRepository, ICar carRepository)
            {
                this.bookingRepository = bookingRepository;
                this.userRepository = userRepository;
                this.carRepository = carRepository;
            }

            public IList<Booking> Booking { get; set; } = default!;
            public TheUser TheUser { get; set; }
            public Car Car { get; set; }


            public async Task OnGetAsync()
            {
                Booking = (await bookingRepository.GetAllBookingAsync()).ToList();

            }
        }
    }



    //public async Task<IActionResult> OnGetCreateBooking(int id)
    //{
    //    CarId = id;
    //    Car = await carRepository.GetCarByIdAsync(CarId);
    //    return Page();
    //}

    ////[BindProperty]
    ////public Booking Booking { get; set; } = default!;
    ////public Car Car { get; set; }
    //public int CarId { get; set; }

    //public IList<Car> Cars { get; set; } = default!;

    //public IList<TheUser> TheUsers { get; set; } = default!;


    //// To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD

    //public async Task<IActionResult> OnPostCreateBookingAsync(int id)
    //{
    //    CarId = id;
    //    Car = await carRepository.GetCarByIdAsync(CarId);
    //    CurrentBooking.Car = Car;
    //    if (int.TryParse(httpContextAccessor.HttpContext.Request.Cookies["userCookie"], out int userId))
    //    {
    //        var loggedInUser = await userRepository.GetUserByIdAsync(userId);
    //        CurrentBooking.TheUser = loggedInUser;
    //    }

    //    var booking = await bookingRepository.AddBookingAsync(CurrentBooking);
    //    CurrentBooking = booking;


    //    return RedirectToPage("/Bookings/BookingIndex");
    //}
}



// To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
//public async Task<IActionResult> OnPostAsync()
//{

//        if (!ModelState.IsValid || Car == null)
//        {
//            return Page();
//}
//var car = await carRepository.AddCarAsync(Car);

//Car = car;

//return RedirectToPage("CarIndex");
//}



//        public async Task OnGetBookingsAsync()
//{
//    Bookings = (await bookingRepository.GetAllBookingAsync()).ToList();
//}

//public async Task<IActionResult> OnGetDetailsAsync(int id)
//{
//    if (id == null)
//    {
//        return NotFound();
//    }

//    var booking = await bookingRepository.GetBookingByIdAsync(id);

//    if (booking == null)
//    {
//        return NotFound();
//    }

//    Bookings = new List<Booking> { booking };
//    return Page();
//}

//public async Task<IActionResult> OnGetDeleteAsync(int id)
//{
//    var booking = await bookingRepository.GetBookingByIdAsync(id);

//    if (booking == null)
//    {
//        return NotFound();
//    }

//    await bookingRepository.DeleteBookingAsync(id);
//    return RedirectToPage("/Bookings/BookingIndex");
//}

//public IActionResult OnGetCreate()
//{
//    return Page();
//}

//[BindProperty]
//public Booking Booking { get; set; }

//public async Task<IActionResult> OnPostCreateAsync()
//{
//    if (!ModelState.IsValid || Booking == null)
//    {
//        return Page();
//    }

//    var addedBooking = await bookingRepository.AddBookingAsync(Booking);
//    return RedirectToPage("/Bookings/BookingIndex");
//}
//    }

