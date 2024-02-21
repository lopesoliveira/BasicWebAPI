using AppSettings.BasicWebAPI.Application.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AppSettings.BasicWebAPI.Application.Identity;

namespace AppSettings.BasicWebAPI.Application {
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);
            var config = builder.Configuration;

            //builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);
            //Hashing HS256 is not the only mechanism to do this. There's also public cryptography but it's the most common
            //Proper way to use the token:
            //Bearer tokenString  - You must write Bearer before the token string
            //In Postman Send Request (usually Post) and go to Headers and write in key: Authorization; Value: Bearer tokenString
            // YOUTUBE TUTORIAL ------ https://www.youtube.com/watch?v=mgeuh8k3I4g

            builder.Services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x => {
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters {
                    ValidIssuer = config["JwtSettings:Issuer"], //builder.Configuration.GetValue("JwtSettings:Issuer"),
                    ValidAudience = config["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtSettings:Key"]!)),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true
                };
            });

            //See also: Identity/IdentityData.cs ---- Se controller how to give permission on delete
            builder.Services.AddAuthorization(options => {
                options.AddPolicy(IdentityData.AdminUserPolicyName , p =>
                    p.RequireClaim(IdentityData.AdminUserClaimName, "true"));
            });

            // Add services to the container.
            builder.Services.AddControllers();

            //retirar o providerOption depois de criar a BD e tabelas || Need to install NuGet Microsoft.EntityFrameworkCore.SqlServer to have the options.UseSqlServer method
            builder.Services.AddDbContext<BasicWebAPISettingsContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BasicWebAPISettingsContext")));
            builder.Services.AddMyDependencyGroup();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            //**builder.Services.AddSwaggerGen();

            //This can move out into a folder called Swagger or SwaggerConfigurations
            builder.Services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1" , new OpenApiInfo { Title = "Demo API" , Version = "v1" });
                option.AddSecurityDefinition("Bearer" , new OpenApiSecurityScheme {
                    In = ParameterLocation.Header ,
                    Description = "Please enter a valid token" ,
                    Name = "Authorization" ,
                    Type = SecuritySchemeType.Http ,
                    BearerFormat = "JWT" ,
                    Scheme = "Bearer"
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme {
                            Reference = new OpenApiReference {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });


            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if(app.Environment.IsDevelopment()) {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();        //Need this to use JWT bearer token
            app.UseAuthorization();         //Need this to use JWT bearer token

            app.MapControllers();

            app.Run();
        }
    }
}
