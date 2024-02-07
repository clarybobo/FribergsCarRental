using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FribergsCarRental.Data;
using FribergsCarRental.Data.Models;

namespace FribergsCarRental.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly ICustomer customerRepository;

        public IndexModel(ICustomer customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public IList<Customer> Customer { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Customer = (await customerRepository.GetAllCustomersAsync()).ToList();
        }
    }
}
