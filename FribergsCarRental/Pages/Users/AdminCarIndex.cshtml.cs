﻿using System;
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
    public class AdminCarIndexModel : PageModel
    {
        private readonly ICar carRepository;

        public AdminCarIndexModel(ICar carRepository)
        {
            this.carRepository = carRepository;
        }

        public IList<Car> Car { get; set; } = default!;
       

        public async Task OnGetAsync()
        {
          Car = (await carRepository.GetAllCarsAsync()).ToList();
        }
    }
}
