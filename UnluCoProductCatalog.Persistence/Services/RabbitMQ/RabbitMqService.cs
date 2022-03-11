using RabbitMQ.Client;
using UnluCoProductCatalog.Application.Interfaces.RabbitMQ;

namespace UnluCoProductCatalog.Persistence.Services.RabbitMQ
{
    public class RabbitMqService : IRabbitMqService
    {

        public IConnection GetRabbitMqConnection()
        {
            ConnectionFactory connectionFactory = new()
            {
                HostName = "localhost"
            };

            return connectionFactory.CreateConnection();
        }
    }

}
