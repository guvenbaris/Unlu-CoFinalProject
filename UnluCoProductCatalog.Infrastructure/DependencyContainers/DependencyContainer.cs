using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using UnluCoProductCatalog.Application.Interfaces.Repositories;
using UnluCoProductCatalog.Application.Interfaces.UnitOfWorks;
using UnluCoProductCatalog.Domain.Entities;
using UnluCoProductCatalog.Infrastructure.Contexts;
using UnluCoProductCatalog.Infrastructure.Repositories;
using UnluCoProductCatalog.Infrastructure.UnitOfWorks;


namespace UnluCoProductCatalog.Infrastructure.DependencyContainers
{
    public static class DependencyContainer 
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ProductCatalogDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("default")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IColorRepository, ColorRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IOfferRepository, OfferRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IUsingStatusRepository, UsingStatusRepository>();
            services.AddScoped<IAccountDetailRepository, AccountDetailRepository>();

            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<ProductCatalogDbContext>().AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateAudience = true,
                        ValidAudience = configuration["Jwt:Audience"],
                        ValidateIssuer = true,
                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidateLifetime = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
                        ClockSkew = TimeSpan.Zero
                    };
                }
            );
        }
    }
}
