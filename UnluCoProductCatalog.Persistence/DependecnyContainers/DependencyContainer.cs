using Microsoft.Extensions.DependencyInjection;
using UnluCoProductCatalog.Application.Interfaces.LogInterfaces;
using UnluCoProductCatalog.Application.Interfaces.Mail;
using UnluCoProductCatalog.Application.Interfaces.RabbitMQ;
using UnluCoProductCatalog.Persistence.Services.LogService;
using UnluCoProductCatalog.Persistence.Services.Mail;
using UnluCoProductCatalog.Persistence.Services.RabbitMQ;


namespace UnluCoProductCatalog.Persistence.DependecnyContainers
{
    public static class DependencyContainer 
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddScoped<ISmtpServer, SmtpServer>();
            services.AddSingleton<IPublisherService, PublisherService>();
            services.AddSingleton<IRabbitMqService, RabbitMqService>();
            services.AddSingleton<ILoggerService, EmailLoggerService>();
        }
    }
}
