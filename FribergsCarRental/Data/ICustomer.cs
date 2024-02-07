using FribergsCarRental.Data.Models;

namespace FribergsCarRental.Data
{
    public interface ICustomer
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int? id);
        Task<Customer> AddCustomerAsync(Customer customer);

        Task<Customer> EditCustomerAsync(Customer customer, int id);
        Task DeleteCustomerAsync(int? id);
    }
}
