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
        private readonly ICar carRepository;
        private readonly IUser userRepository;

        public AdminPageModel(ICar carRepository, IUser userRepository)
        {
            this.carRepository = carRepository;
            this.userRepository = userRepository;
        }

        public IList<Car> Cars { get; set; } = default!;

        public IActionResult OnGet()
        {
           return Page(); 
        }
        public IActionResult OnGetCars()
        {
            return  RedirectToPage("/Cars/CarIndex");
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
