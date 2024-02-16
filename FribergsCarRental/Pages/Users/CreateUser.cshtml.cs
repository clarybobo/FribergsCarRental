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

            var user = await userRepository.AddUserAsync(TheUser);
            TheUser = user;


            string userCookie = user.TheUserId.ToString();

            //Skapar upp en instans av inbyggda Cookie-klassen
            CookieOptions options = new CookieOptions();

            await userRepository.GetUserByEmailAsync(TheUser.Email);

            httpContextAccessor.HttpContext.Response.Cookies.Append("userFirstName", user.FirstName, options);
            httpContextAccessor.HttpContext.Response.Cookies.Append("customerCookie", userCookie, options);
            return RedirectToPage("/Users/CustomerPage");

        }
    }
}

