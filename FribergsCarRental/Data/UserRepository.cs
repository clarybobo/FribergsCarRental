﻿using FribergsCarRental.Data.Models;
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

        public async Task<IEnumerable<TheUser>> GetAllUsersAsync()
        {
            return await applicationDbContext.TheUsers.OrderBy(u => u.TheUserId).ToListAsync();
        }

        public async Task<TheUser> GetUserByIdAsync(int? id)
        {
            return await applicationDbContext.TheUsers.FirstOrDefaultAsync(u => u.TheUserId == id);            
        }

        public async Task<TheUser> AddUserAsync(TheUser user)
        {
            applicationDbContext.TheUsers.Add(user);
            await applicationDbContext.SaveChangesAsync();
            return user;
        }

        public async Task DeleteUserAsync(int? id)
        {
            var user = await applicationDbContext.TheUsers.FirstOrDefaultAsync(u => u.TheUserId == id);

            if (user != null)
            {
                applicationDbContext.Remove(user);
                await applicationDbContext.SaveChangesAsync();
            }
        }

        public async Task<TheUser> EditUserAsync(TheUser user, int id)
        {
            var existingUser = await applicationDbContext.TheUsers.FirstOrDefaultAsync(u => u.TheUserId == id);
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

        public async Task<TheUser> GetUserByEmailAsync(string email)
        {
            return await applicationDbContext.TheUsers.FirstOrDefaultAsync(u => u.Email == email);            
        }   
            
    }
}
