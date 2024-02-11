using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FribergsCarRental.Data;
using FribergsCarRental.Data.Models;

namespace FribergsCarRental.Pages.Cars
{
    public class CarIndexModel : PageModel
    {
        private readonly ICar carRepository;
        private readonly IUser userRepository;

        public CarIndexModel(ICar carRepository, IUser userRepository)
        {
            this.carRepository = carRepository;
            this.userRepository = userRepository;
        }

        public IList<Car> Car { get; set; } = default!;
        //public IList<TheUser> TheUsers { get; set; } = default!;

        public TheUser TheUser { get; set; }

        public async Task OnGetAsync()
        {
            Car = (await carRepository.GetAllCarsAsync()).ToList();
            //TheUsers = (await userRepository.GetAllUsersAsync()).ToList();
        }
    }
}
