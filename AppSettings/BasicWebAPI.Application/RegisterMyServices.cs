using AppSettings.BasicWebAPI.Application.Contexts;

namespace AppSettings.BasicWebAPI.Application {
    public static class RegisterMyServices {
        public static IServiceCollection AddMyDependencyGroup(this IServiceCollection services) {
            services.AddScoped<IBasicWebAPISettingsContext , BasicWebAPISettingsContext>();
            return services;
        }
    }
}
