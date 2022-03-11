using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UnluCoProductCatalog.Application.Enums;
using UnluCoProductCatalog.Application.Interfaces.Mail;
using UnluCoProductCatalog.Application.Interfaces.RabbitMQ;
using UnluCoProductCatalog.Persistence.Services.Mail;
using UnluCoProductCatalog.Persistence.Services.RabbitMQ;

namespace UnluCoProductCatalog.ConsoleConsumer
{
   class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            var consumer = host.Services.GetRequiredService<Consumer>();

            var queue = RabbitMqQueue.EmailSenderQueue.ToString();

            consumer.Start(queue);
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).ConfigureServices((services) =>
            {
                services.AddScoped<IConfiguration>(_ => new ConfigurationBuilder().AddJsonFile($"C:/Users/Barış/source/repos/UnluCoProductCatalog/WebAPI/appsettings.json").Build());
                services.AddScoped<IPublisherService, PublisherService>();
                services.AddScoped<IRabbitMqService, RabbitMqService>();
                services.AddScoped<ISmtpServer, SmtpServer>();
                services.AddTransient<Consumer>();
            });


    }
}
