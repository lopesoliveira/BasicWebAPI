using AppSettings.BasicWebAPI.Application.Contexts;
using AppSettings.BasicWebAPI.Application.Services.Interfaces;

namespace AppSettings.BasicWebAPI.Application.Services
{
    public static class RegisterMyServices
    {
        public static IServiceCollection AddMyDependencyGroup(this IServiceCollection services)
        {
            services.AddScoped<IBasicWebAPISettingsContext, BasicWebAPISettingsContext>();
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
            services.AddTransient<IAuthService, AuthService>();
            return services;
        }
    }
}
