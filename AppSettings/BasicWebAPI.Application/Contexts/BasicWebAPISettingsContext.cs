using AppSettings.BasicWebAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppSettings.BasicWebAPI.Application.Contexts {
    public class BasicWebAPISettingsContext : DbContext, IBasicWebAPISettingsContext {
        public BasicWebAPISettingsContext(DbContextOptions<BasicWebAPISettingsContext> options) : base(options) {
        }
        public DbSet<Login> Login { get; set; }
    }
}
