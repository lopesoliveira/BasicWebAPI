using AppSettings.BasicWebAPI.Application.Utils;
using AppSettings.BasicWebAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppSettings.BasicWebAPI.Application.Contexts {
    public interface IApplicationDbContext: IDbContext {
        DbSet<LoginModel> LoginModels { get; set; }
        DbSet<RegistrationModel> RegistrationModels { get; set; }
    }
}
