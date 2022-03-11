using System.Text;
using RabbitMQ.Client;
using UnluCoProductCatalog.Application.Interfaces.RabbitMQ;
using UnluCoProductCatalog.Application.ViewModels.EmailViewModels;

namespace UnluCoProductCatalog.Persistence.Services.RabbitMQ
{
    public class PublisherService : IPublisherService
    {
        private readonly IRabbitMqService _rabbitMqService;

        public PublisherService(IRabbitMqService rabbitMqService)
        {
            _rabbitMqService = rabbitMqService;
        }

        public void Publish(EmailToSend email,string queueName)
        {
            using var connection = _rabbitMqService.GetRabbitMqConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queueName, false, false, false, null);
            var body = Encoding.UTF8.GetBytes(System.Text.Json.JsonSerializer.Serialize(email));

            channel.BasicPublish("", queueName, null, body: body);
        }
    }
}

