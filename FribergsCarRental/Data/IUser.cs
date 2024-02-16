using FribergsCarRental.Data.Models;

namespace FribergsCarRental.Data
{
    public interface IUser
    {
       
        Task<IEnumerable<TheUser>> GetAllUsersAsync();
        Task<TheUser> GetUserByIdAsync(int? id);
        Task<TheUser> GetUserByEmailAsync(string email);
        Task<TheUser> AddUserAsync(TheUser user);
        Task<TheUser> EditUserAsync(TheUser user, int id);
        Task DeleteUserAsync(int? id);
        Task<int> GetLoggedInUserIdAsync(string email);


    }
}
