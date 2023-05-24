using BusinessContact.Service.DTOs.Login;

namespace BusinessContact.Service.Interfaces
{
    public interface IAuthService
    {
        Task<LoginForResultDto> AuthenticateAsync(string email, string password);
    }
}
