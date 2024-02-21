using Company.Company.Application.Contexts;

namespace Company.Company.Application {
    public static class RegisterMyServices {
        public static IServiceCollection AddMyDependencyGroup(this IServiceCollection services) {
           
            services.AddScoped<ICompanyContext, CompanyContext>();
            return services;
        }
    }
}
