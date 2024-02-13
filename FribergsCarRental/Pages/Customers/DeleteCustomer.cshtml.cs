using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FribergsCarRental.Data;
using FribergsCarRental.Data.Models;

//namespace FribergsCarRental.Pages.Customers
//{
//    public class DeleteModel : PageModel
//    {
//        private readonly ICustomer customerRepository;

//        public DeleteModel(ICustomer customerRepository)
//        {
//            this.customerRepository = customerRepository;
//        }

//        [BindProperty]
//        public Customer Customer { get; set; } = default!;

//        public async Task<IActionResult> OnGetAsync(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var customer = await customerRepository.GetCustomerByIdAsync(id);

//            if (customer == null)
//            {
//                return NotFound();
//            }
//            Customer = customer;
//            return Page();
//        }

//        public async Task<IActionResult> OnPostAsync(int? id)
//        {
//            var customer = await customerRepository.GetCustomerByIdAsync(id);

//            if (customer == null)
//            {
//                return NotFound();
//            }
            
//            await customerRepository.DeleteCustomerAsync(id);
//            return RedirectToPage("CustomerIndex");
//        }
//    }
//}
