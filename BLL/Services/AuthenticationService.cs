using BLL.DTOs;
using BLL.Interfaces;
using DAL.Data;
using DAL.Models;

namespace BLL.Services
{
    public class AuthenticationService : IAuthService
    {
        private readonly AppDbContext Context;

        public AuthenticationService(AppDbContext context)
        {
            Context = context;
        }

        public User AuthenticateUser(SignInDto model)
        {
            // Logic for user authentication
            var user = Context.Users.FirstOrDefault(u => u.UserName == model.UserName);
            return user != null && user.Password == model.Password ? user : null;
        }
    }
}
 