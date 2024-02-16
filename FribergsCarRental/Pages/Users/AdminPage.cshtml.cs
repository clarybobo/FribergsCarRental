using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FribergsCarRental.Data;
using FribergsCarRental.Data.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FribergsCarRental.Pages.Users
{
    public class AdminPageModel : PageModel
    {


        private readonly IBooking bookingRepository;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IUser userRepository;
        private readonly ICar carRepository;

        public AdminPageModel(IBooking bookingRepository, IHttpContextAccessor httpContextAccessor, IUser userRepository, ICar carRepository)
        {
            this.bookingRepository = bookingRepository;
            this.httpContextAccessor = httpContextAccessor;
            this.userRepository = userRepository;
            this.carRepository = carRepository;
        }

        public IList<Booking> Bookings { get; set; } = default!;
        public IList<TheUser> TheUsers { get; set; } = default!;
        public IList<Car> Cars { get; set; } = default!;

        public string AdminCookie { get; set; }



        public async Task OnGetAsync()
        {
            Bookings = (await bookingRepository.GetAllBookingAsync()).ToList();
            TheUsers = (await userRepository.GetAllUsersAsync()).ToList();
            Cars = (await carRepository.GetAllCarsAsync()).ToList();
            AdminCookie = httpContextAccessor.HttpContext.Request.Cookies["adminCookie"];
        }

    }
}

