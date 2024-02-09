using FribergsCarRental.Data.Models;

namespace FribergsCarRental.Data
{
    public interface IUser
    {
        //Task<User> GetUserByEmailAsync(string email);
        //Task<User> GetUserByIdAsync(int id);
        //Task<User> AddUserAsync(User user);
        Task<IEnumerable<TheUser>> GetAllUsersAsync();
        Task<TheUser> GetUserByIdAsync(int? id);
        Task<TheUser> GetUserByEmailAsync(string email);
        Task<TheUser> AddUserAsync(TheUser user);
        Task<TheUser> EditUserAsync(TheUser user, int id);
        Task DeleteUserAsync(int? id);
        Task<int> GetLoggedInUserIdAsync(string email);


    }
}
