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
    public class IndexModel : PageModel
    {
        private readonly IUser userRepository;
       

        public IndexModel(IUser userRepository)
        {
            this.userRepository = userRepository;            
        }


        [BindProperty]
        public TheUser TheUser { get; set; } = new TheUser();

        public IActionResult OnGet()
        {
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || TheUser == null)
            {
                return Page();
            }


            //Instanserar upp en user - kopplar samman den till TheUser
            var user = await userRepository.AddUserAsync(TheUser);
            TheUser = user;

      
            return RedirectToPage("/Users/AdminPage");

        }

    }
}
