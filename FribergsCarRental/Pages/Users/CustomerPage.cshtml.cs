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
    public class CustomerPageModel : PageModel
    {
        private readonly ICar carRepository;
        private readonly IUser userRepository;

        public CustomerPageModel(ICar carRepository, IUser userRepository)
        {
            this.carRepository = carRepository;
            this.userRepository = userRepository;
        }

        public IList<Car> Car { get; set; } = default!;
        public IList<TheUser> TheUser { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Car = (await carRepository.GetAllCarsAsync()).ToList();
            TheUser = (await userRepository.GetAllUsersAsync()).ToList();
        }

    }
    //{
    //    private readonly ICar carRepository;
    //    private readonly IUser userRepository;


    //    public CustomerPageModel(ICar carRepository, IUser userRepository)
    //    {
    //        this.carRepository = carRepository;
    //        this.userRepository = userRepository;
    //    }

    //    public IList<Car> Car { get; set; } = default!;
    //    public string FirstName { get; set; }

    //    public IActionResult OnGet()
    //    {
    //        return Page();
    //    }
    //    public IActionResult OnGetCars()
    //    {
    //        return RedirectToPage("/Cars/CarIndex");
    //    }

    //    public IActionResult OnGetUsers()
    //    {
    //        return RedirectToPage("/Users/UserIndex");
    //    }
}
