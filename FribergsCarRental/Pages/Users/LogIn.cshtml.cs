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
            //hämtar en användare från databasen via användarens e-mail
            var user = await userRepository.GetUserByEmailAsync(TheUser.Email);

            if (user != null && user.Password == TheUser.Password)
            {
                //omvanddlar användar-ID till en string för att kunna lagra det i en cookie
                string userCookie = user.TheUserId.ToString();

                //För att cookies ska kunna skapas instanseras en instans av Cookie-klassen - "options"
                CookieOptions options = new CookieOptions();


                //användarens namn blir till en cookie "userFirstName"
                httpContextAccessor.HttpContext.Response.Cookies.Append("userFirstName", user.FirstName, options);

                //är användaren admin tilldelas en adminCookie som innehåller användarens id
                if (user.IsAdmin)
                {
                    httpContextAccessor.HttpContext.Response.Cookies.Append("adminCookie", userCookie, options);
                    return RedirectToPage("/Users/AdminPage");
                }
                //annars tilldelas en customerCookie med användarens id
                else
                {
                    httpContextAccessor.HttpContext.Response.Cookies.Append("customerCookie", userCookie, options);
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
