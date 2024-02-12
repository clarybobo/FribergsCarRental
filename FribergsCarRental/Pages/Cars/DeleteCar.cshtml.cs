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
    public class DeleteModel : PageModel
    {
        private readonly ICar carRepository;

        public DeleteModel(ICar carRepository)
        {
            this.carRepository = carRepository;
        }

        [BindProperty]
        public Car Car { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await carRepository.GetCarByIdAsync(id);

            if (car == null)
            {
                return NotFound();
            }
            Car = car;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            var car = await carRepository.GetCarByIdAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            await carRepository.DeleteCarAsync(id);
            return RedirectToPage("/Users/AdminCarIndex");
        }
    }
}