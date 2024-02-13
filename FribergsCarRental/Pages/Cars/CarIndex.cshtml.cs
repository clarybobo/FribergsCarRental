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
        private readonly IHttpContextAccessor httpContextAccessor;

        public CarIndexModel(ICar carRepository, IHttpContextAccessor httpContextAccessor)
        {
            this.carRepository = carRepository;
            this.httpContextAccessor = httpContextAccessor;
        }

        public IList<Car> Car { get; set; } = default!;
  

        public async Task OnGetAsync()
        {
            Car = (await carRepository.GetAllCarsAsync()).ToList();

        }
    }
}
