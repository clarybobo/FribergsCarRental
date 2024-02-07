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
    public class AdminPageModel : PageModel
    {
        private readonly FribergsCarRental.Data.ApplicationDbContext _context;

        public AdminPageModel(FribergsCarRental.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<TheUser> TheUser { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.TheUsers != null)
            {
                TheUser = await _context.TheUsers.ToListAsync();
            }
        }
    }
}
