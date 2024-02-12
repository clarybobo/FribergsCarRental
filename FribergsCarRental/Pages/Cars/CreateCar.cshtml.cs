using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FribergsCarRental.Data;
using FribergsCarRental.Data.Models;

namespace FribergsCarRental.Pages.Cars
{
    public class CreateModel : PageModel
    {
        private readonly ICar carRepository;

        public CreateModel(ICar carRepository)
        {
            this.carRepository = carRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Car Car { get; set; } = new Car();


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid || Car == null)
            {
                return Page();
            }
            var car = await carRepository.AddCarAsync(Car);

            Car = car;

            return RedirectToPage("/Users/AdminCarIndex");
        }
    }
}
