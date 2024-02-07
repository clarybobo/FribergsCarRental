using FribergsCarRental.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FribergsCarRental.Data
{
    public class UserRepository : IUser
    {
        private readonly ApplicationDbContext applicationDbContext;

        public UserRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await applicationDbContext.Users.OrderBy(u => u.UserId).ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int? id)
        {
            var user = await applicationDbContext.Users.FirstOrDefaultAsync(u => u.UserId == id);
            return user;
        }

        public async Task<User> AddUserAsync(User user)
        {
            applicationDbContext.Users.Add(user);
            await applicationDbContext.SaveChangesAsync();
            return user;
        }

        public async Task DeleteUserAsync(int? id)
        {
            var user = await applicationDbContext.Users.FirstOrDefaultAsync(u => u.UserId == id);

            if (user != null)
            {
                applicationDbContext.Remove(user);
                await applicationDbContext.SaveChangesAsync();
            }
        }

        public async Task<User> EditUserAsync(User user, int id)
        {
            var existingUser = await applicationDbContext.Users.FirstOrDefaultAsync(u => u.UserId == id);
            if (existingUser != null)
            {
                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.Email = user.Email;
                existingUser.Password = user.Password;
                await applicationDbContext.SaveChangesAsync();
                return existingUser;
            }
            return null;
        }
        //public Task<User> AddUserAsync(User user)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<User> GetUserByEmailAsync(string email)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<User> GetUserByIdAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
