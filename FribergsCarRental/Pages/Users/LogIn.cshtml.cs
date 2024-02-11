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
        private readonly IHttpContextAccessor httpContextAccessor;

        public LogInModel(IUser userRepository, IHttpContextAccessor httpContextAccessor)
        {
            this.userRepository = userRepository;
            this.httpContextAccessor = httpContextAccessor;
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
            var userId = await userRepository.GetLoggedInUserIdAsync(TheUser.Email);
            string userCookie = userId.ToString();
           
            CookieOptions options = new CookieOptions();
            if (user != null && user.Password == TheUser.Password)
            {
                if (user.IsAdmin)
                {                    
                    httpContextAccessor.HttpContext.Response.Cookies.Append("userCookie", userCookie, options);
                    return RedirectToPage("/Users/AdminPage");
                }
                else
                {                    
                    httpContextAccessor.HttpContext.Response.Cookies.Append("userCookie", userCookie, options);
                    return RedirectToPage("/Users/CustomerPage");
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
