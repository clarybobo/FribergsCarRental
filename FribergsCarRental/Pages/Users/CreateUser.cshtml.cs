using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FribergsCarRental.Data;
using FribergsCarRental.Data.Models;

namespace FribergsCarRental.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly IUser userRepository;

        public CreateModel(IUser userRepository)
        {
            this.userRepository = userRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public User TheUser { get; set; } = new User();
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || TheUser == null)
            {
                return Page();
            }
            var user = await userRepository.AddUserAsync(TheUser);

            TheUser = user;

            return RedirectToPage("UserIndex");
        }
    }
}
