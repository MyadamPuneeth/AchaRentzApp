using DAL.Models;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        Task AddUserAsync(User user);
        Task<User> GetUserByIdAsync(int id);
        Task UpdateUserAsync(int id, User model);
    }
}
