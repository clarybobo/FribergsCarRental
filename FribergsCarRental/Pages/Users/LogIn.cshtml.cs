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

    public class LogInModel : PageModel
    {
        private readonly IUser userRepository;

        public LogInModel(IUser userRepository)
        {
            this.userRepository = userRepository;            
        }
       
            [BindProperty]
            public TheUser TheUser { get; set; }

            public IActionResult OnGet()
            {
                return Page();
            }

            public async Task<IActionResult> OnPostAsync()
            {
                var user = await userRepository.GetUserByEmailAsync(TheUser.Email);

                if (user != null && user.Password == TheUser.Password)
                {
                    // Authentication successful
                    // Redirect user to appropriate page based on their role
                    if (user.IsAdmin)
                    {
                        return RedirectToPage("/Users/UserIndex"); // Admin dashboard page
                    }
                    else
                    {
                        return RedirectToPage("/Users/UserIndex"); // User dashboard page
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid email or password");
                    return Page();
                }
            }
        }

       
    }
