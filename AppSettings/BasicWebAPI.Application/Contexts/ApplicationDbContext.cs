using AppSettings.BasicWebAPI.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AppSettings.BasicWebAPI.Application.Contexts {
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
        }
        public DbSet<LoginModel> LoginModels { get; set; }
        public DbSet<RegistrationModel> RegistrationModels { get; set; }
    }
}
