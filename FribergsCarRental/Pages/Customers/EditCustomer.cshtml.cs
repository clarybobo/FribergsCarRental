﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FribergsCarRental.Data;
using FribergsCarRental.Data.Models;

namespace FribergsCarRental.Pages.Customers
{
    public class EditModel : PageModel
    {
        private readonly ICustomer customerRepository;

        public EditModel(ICustomer customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        [BindProperty]
        public Customer Customer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await customerRepository.GetCustomerByIdAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            Customer = customer;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var editedCustomer = await customerRepository.EditCustomerAsync(Customer, Customer.CustomerId);
                if (editedCustomer == null)
                {
                    return NotFound();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                var existingCustomer = customerRepository.GetCustomerByIdAsync(Customer.CustomerId);
                if (existingCustomer == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("CustomerIndex");
        }
    }
}
