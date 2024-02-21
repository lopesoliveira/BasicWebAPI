using AppSettings.BasicWebAPI.Application.Utils;
using AppSettings.BasicWebAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppSettings.BasicWebAPI.Application.Contexts {
    public interface IBasicWebAPISettingsContext : IDbContext {
        DbSet<Login> Login { get; set; }
    }
}
