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

            //Lägger till en användare och kopplar ihop användarvariabeln med användarpropertyn
            var user = await userRepository.AddUserAsync(TheUser);
            TheUser = user; 

            var userId = await userRepository.GetLoggedInUserIdAsync(TheUser.Email);
            string userCookie = userId.ToString(); //Användarens id omvandlas till en string för att cookies ska kunna lagra id

            CookieOptions options = new CookieOptions();      
                   
            if (user.IsAdmin)
            {
                httpContextAccessor.HttpContext.Response.Cookies.Append("adminCookie", userCookie, options);
                return RedirectToPage("/Users/Login");
            }
            else
            {
                httpContextAccessor.HttpContext.Response.Cookies.Append("customerCookie", userCookie, options);
                return RedirectToPage("/Users/Login");
            }
        }
    }
}
