﻿using Company.Company.Application.Contexts;
using Microsoft.DotNet.Scaffolding.Shared.ProjectModel;

namespace Company.Company.Application {
    public static class RegisterMyServices {
        public static IServiceCollection AddMyDependencyGroup(this IServiceCollection services) {
           
            services.AddScoped<ICompanyContext, CompanyContext>();   

            return services;
        }
    }
}