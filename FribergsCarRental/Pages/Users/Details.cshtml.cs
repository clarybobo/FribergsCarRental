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
    public class DetailsModel : PageModel
    {
        private readonly FribergsCarRental.Data.ApplicationDbContext _context;

        public DetailsModel(FribergsCarRental.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public TheUser TheUser { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TheUsers == null)
            {
                return NotFound();
            }

            var user = await _context.TheUsers.FirstOrDefaultAsync(m => m.TheUserId == id);
            if (user == null)
            {
                return NotFound();
            }
            else 
            {
                TheUser = user;
            }
            return Page();
        }
    }
}
