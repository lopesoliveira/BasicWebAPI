using AppSettings.BasicWebAPI.Domain.Entities;

namespace AppSettings.BasicWebAPI.Application.Services.Interfaces
{
    public interface IAuthService
    {
        Task<(int, string)> Registration(RegistrationModel model, string role);
        Task<(int, string)> Login(LoginModel model);
    }
}
