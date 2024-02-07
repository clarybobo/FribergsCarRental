using FribergsCarRental.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FribergsCarRental.Data
{
    public class CustomerRepository : ICustomer
    {
        private readonly ApplicationDbContext applicationDbContext;
        public CustomerRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await applicationDbContext.Customers.OrderBy(c => c.CustomerId).ToListAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int? id)
        {
           var customer = await applicationDbContext.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
           return customer; 
           
        }

        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            applicationDbContext.Customers.Add(customer);
            await applicationDbContext.SaveChangesAsync();
            return customer;
        }

        public async Task DeleteCustomerAsync(int? id)
        {
            var customer = await applicationDbContext.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);

            if (customer != null)
            {
                applicationDbContext.Remove(customer);
                await applicationDbContext.SaveChangesAsync();
            }
        }

        public async Task<Customer> EditCustomerAsync(Customer customer, int id)
        {
            var existingCustomer = await applicationDbContext.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
            if (existingCustomer != null)
            {
                existingCustomer.FirstName = customer.FirstName;
                existingCustomer.LastName = customer.LastName;
                existingCustomer.Email = customer.Email;
                existingCustomer.Password = customer.Password;
                await applicationDbContext.SaveChangesAsync();
                return existingCustomer;
            }
            return null;
        }
    }
}

