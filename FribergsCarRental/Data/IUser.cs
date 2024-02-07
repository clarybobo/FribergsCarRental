using FribergsCarRental.Data.Models;

namespace FribergsCarRental.Data
{
    public interface IUser
    {
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserByIdAsync(int id);
        Task<User> AddUserAsync(User user);
    }
}
