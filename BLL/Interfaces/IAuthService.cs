using BLL.DTOs;
using DAL.Models;

namespace BLL.Interfaces
{
    public interface IAuthService
    {
        User AuthenticateUser(SignInDto model);
    }
}
