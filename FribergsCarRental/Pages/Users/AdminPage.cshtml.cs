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
        private readonly IHttpContextAccessor httpContextAccessor;

        //private readonly ICar carRepository;
        //private readonly IUser userRepository;

        public AdminPageModel(IHttpContextAccessor httpContextAccessor/*ICar carRepository, IUser userRepository*/)
        {
            this.httpContextAccessor = httpContextAccessor;
            //this.carRepository = carRepository;
            //this.userRepository = userRepository;
        }

        public IList<Car> Cars { get; set; } = default!;
        public string UserCookie { get; set; }

        public IActionResult OnGet()
        {
            UserCookie = httpContextAccessor.HttpContext.Request.Cookies["userCookie"];
            return Page(); 
        }
        public IActionResult OnGetCars()
        {
            return  RedirectToPage("/Users/UserCarIndex");
        }

        public IActionResult OnGetUsers()
        {
            return RedirectToPage("/Users/UserIndex");
        }

        public IActionResult OnGetBookings()
        {
            return RedirectToPage("/Bookings/BookingIndex");
        }
    }
}
