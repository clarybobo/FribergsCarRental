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
    public class IndexModel : PageModel
    {
        private readonly IUser userRepository;

        public IndexModel(IUser userRepository)
        {
            this.userRepository = userRepository;
        }

        public IList<User> TheUser { get; set; } = default!;

        public async Task OnGetAsync()
        {
            TheUser = (await userRepository.GetAllUsersAsync()).ToList();
        }
    }
}
