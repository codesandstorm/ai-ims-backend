using AIIMS.Domain.Entities;

namespace AIIMS.Application.Auth
{
    public interface IAuthService
    {
        Task<string?> Login(string email, string password);
    }
}