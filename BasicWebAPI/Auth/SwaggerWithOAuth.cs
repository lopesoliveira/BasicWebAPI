using Microsoft.OpenApi.Models;

namespace BasicWebAPI.Auth {
    public static class SwaggerWithOAuth {
        public static IServiceCollection AddSwaggerWithOAuth(this IServiceCollection services,
            string serviceName, string serviceVersion,
            bool isDevelopmentEnvironment=true, bool developmentEnvironmentOnly = false) {

            services.AddSwaggerGen(c => {

                c.SwaggerDoc(serviceVersion, new OpenApiInfo { Title = serviceName, Version = serviceVersion });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme {
                            Reference = new OpenApiReference {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });

                //services.AddSwaggerGenNewtonsoftSupport();
            });
            return services;
        }
    }
}
