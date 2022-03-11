using System;
using System.Reflection;
using WebAPI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UnluCoProductCatalog.Application.Interfaces.LogInterfaces;
using UnluCoProductCatalog.Application.Interfaces.Repositories;
using UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces;
using UnluCoProductCatalog.Application.Interfaces.UnitOfWorks;
using UnluCoProductCatalog.Application.Services;
using UnluCoProductCatalog.Application.ViewModels.CategoryViewModels;
using UnluCoProductCatalog.Domain.Entities;
using UnluCoProductCatalog.Infrastructure.Contexts;
using UnluCoProductCatalog.Infrastructure.Repositories;
using UnluCoProductCatalog.Infrastructure.UnitOfWorks;
using UnluCoProductCatalog.Persistence.Services.LogService;


namespace UnluCoProductCatalog.EntegrasyonTests.Common
{
    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration) : base(configuration)
        {
          
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddApplicationPart(typeof(Startup).Assembly);
            services.AddDbContext<ProductCatalogDbContext>(options => options.UseInMemoryDatabase("Category"));
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //services.AddAutoMapper(Assembly.GetAssembly(typeof(CategoryViewModel)));
            services.AddAutoMapper(typeof(CategoryViewModel), typeof(CommandCategoryViewModel));


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

            services.AddSingleton<ILoggerService, ConsoleLoggerService>();

        }

        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ProductCatalogDbContext>();
            AddCategory(context);

            base.Configure(app,env);
        }

        private void AddCategory(ProductCatalogDbContext context)
        {
            for (int i = 0; i < 15; i++)
            {
                Category category = new Category
                {
                    CategoryName = "Test"+i.ToString(),
                    CreatedDate = DateTime.Now.AddDays(1)
                };
                context.Categories.Add(category);
            };
            context.SaveChanges();
        }
    }
}

