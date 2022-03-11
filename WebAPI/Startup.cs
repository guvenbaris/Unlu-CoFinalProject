using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using UnluCoProductCatalog.Application.DependencyContainers;
using UnluCoProductCatalog.Application.Interfaces.LogInterfaces;
using UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces;
using UnluCoProductCatalog.Application.Services;
using UnluCoProductCatalog.Infrastructure.DependencyContainers;
using UnluCoProductCatalog.Persistence.DependecnyContainers;
using UnluCoProductCatalog.Persistence.Services.LogService;
using WebAPI.Middlewares;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public virtual  void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            services.AddApplicationServices();
            services.AddInfrastructureServices(Configuration);
            services.AddPersistenceServices();

            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "WebAPI", Version = "v1"}); });

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IAccountDetailService, AccountDetailService>();
            services.AddScoped<IOfferService, OfferService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IColorService, ColorService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IUsingStatusService, UsingStatusService>();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public virtual  void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
            }

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseCustomeExceptionMiddle();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

    }
}
