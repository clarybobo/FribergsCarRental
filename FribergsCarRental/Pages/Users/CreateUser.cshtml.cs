using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FribergsCarRental.Data;
using FribergsCarRental.Data.Models;
using Microsoft.AspNetCore.Http;

namespace FribergsCarRental.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly IUser userRepository;
        private readonly IHttpContextAccessor httpContextAccessor;

        public CreateModel(IUser userRepository, IHttpContextAccessor httpContextAccessor)
        {
            this.userRepository = userRepository;
            this.httpContextAccessor = httpContextAccessor;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TheUser TheUser { get; set; } = new TheUser();
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || TheUser == null)
            {
                return Page();
            }
            var user = await userRepository.AddUserAsync(TheUser);

            TheUser = user;




     
            var userId = await userRepository.GetLoggedInUserIdAsync(TheUser.Email);
            string userCookie = userId.ToString();

            CookieOptions options = new CookieOptions();
            
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
    }
}
