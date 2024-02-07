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
    public class DeleteModel : PageModel
    {
        private readonly IUser userRepository;

        public DeleteModel(IUser userRepository)
        {
            this.userRepository = userRepository;
        }

        [BindProperty]
      public TheUser TheUser { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await userRepository.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            TheUser = user;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            var user = await userRepository.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            await userRepository.DeleteUserAsync(id);
            return RedirectToPage("UserIndex");
        }
    }
}
