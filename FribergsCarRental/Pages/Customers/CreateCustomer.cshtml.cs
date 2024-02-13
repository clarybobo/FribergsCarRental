using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FribergsCarRental.Data;
using FribergsCarRental.Data.Models;

namespace FribergsCarRental.Pages.Customers
{
    //public class CreateModel : PageModel
    //{
    //    private readonly ICustomer customerRepository;

    //    public CreateModel(ICustomer customerRepository)
    //    {
    //        this.customerRepository = customerRepository; 
    //    }

    //    public IActionResult OnGet()
    //    {
    //        return Page();
    //    }

    //    [BindProperty]
    //    public Customer Customer { get; set; } = new Customer();


    //    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    //    public async Task<IActionResult> OnPostAsync()
    //    {

    //        if (!ModelState.IsValid || Customer == null)
    //        {
    //            return Page();
    //        }
    //        var customer = await customerRepository.AddCustomerAsync(Customer);

    //        Customer = customer;

    //        return RedirectToPage("CustomerIndex");
    //    }
    //}
}