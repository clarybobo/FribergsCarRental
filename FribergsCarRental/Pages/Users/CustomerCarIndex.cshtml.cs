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
       
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ICar carRepository;

        public CustomerCarIndexModel(IHttpContextAccessor httpContextAccessor, ICar carRepository)
        {
          
            this.httpContextAccessor = httpContextAccessor;
            this.carRepository = carRepository;
        }

        public IList<Car> Cars { get; set; } = default!;
 
        public string CustomerCookie { get; set; }



        public async Task OnGetAsync()
        {
            Cars = (await carRepository.GetAllCarsAsync()).ToList();
            CustomerCookie = httpContextAccessor.HttpContext.Request.Cookies["userCookie"];
            //TheUsers = (await userRepository.GetAllUsersAsync()).ToList();
        }
    }
}
