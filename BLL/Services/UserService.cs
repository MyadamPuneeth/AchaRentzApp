using DAL.Data;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using BLL.Interfaces;
using System;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext Context;

        public UserService(AppDbContext context)
        {
            Context = context;
        }

        public async Task AddUserAsync(User user)
        {
            Context.Users.Add(user);
            await Context.SaveChangesAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await Context.Users.SingleOrDefaultAsync(u => u.UserId == id);
        }

        public async Task UpdateUserAsync(int id, User model)
        {
            var user = await Context.Users.SingleOrDefaultAsync(u => u.UserId == id);
            if (user != null)
            {
                user.Address = model.Address;
                user.Email = model.Email;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.PhoneNumber = model.PhoneNumber;
                user.AlternatePhoneNumber = model.AlternatePhoneNumber;
                user.UserType = "User";

                await Context.SaveChangesAsync();
            }
        }
    }
}
