using EMS.Data.DTOs;
using EMS.Data.Models;

namespace EMS.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<LoginResponse> LoginAsync(string email, string password);
        Task<User> RegisterAsync(RegisterRequest request);
        Task<bool> VerifyPasswordAsync(string password, string hash);
    }
}
