using RabbitMQ.Client;

namespace UnluCoProductCatalog.Application.Interfaces.RabbitMQ
{
    public interface IRabbitMqService
    {
        IConnection GetRabbitMqConnection();
    }
}
