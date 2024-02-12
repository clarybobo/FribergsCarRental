using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FribergsCarRental.Data;
using FribergsCarRental.Data.Models;

namespace FribergsCarRental.Pages.Users
{
    public class CustomerCarIndexModel : PageModel
    {
        private readonly ICar carRepository;
        private readonly IHttpContextAccessor httpContextAccessor;

        public CustomerCarIndexModel(ICar carRepository, IHttpContextAccessor httpContextAccessor)
        {
            this.carRepository = carRepository;
            this.httpContextAccessor = httpContextAccessor;
        }

        public IList<Car> Car { get; set; } = default!;
        public string CustomerCookie { get; set; }



        public async Task OnGetAsync()
        {
            Car = (await carRepository.GetAllCarsAsync()).ToList();
            CustomerCookie = httpContextAccessor.HttpContext.Request.Cookies["userCookie"];
            //TheUsers = (await userRepository.GetAllUsersAsync()).ToList();
        }
    }
}
