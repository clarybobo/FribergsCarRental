using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FribergsCarRental.Data;
using FribergsCarRental.Data.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FribergsCarRental.Pages.Users
{
    public class CustomerPageModel : PageModel
    {

        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IBooking bookingRepository;

        public CustomerPageModel(IHttpContextAccessor httpContextAccessor, IBooking bookingRepository)
        {

            this.httpContextAccessor = httpContextAccessor;
            this.bookingRepository = bookingRepository;
        }
               
        [BindProperty]
        public string UserFirstName { get; set; }

                public void OnGet()
        {
            UserFirstName = httpContextAccessor.HttpContext.Request.Cookies["userFirstName"];           
        }

    }
}


