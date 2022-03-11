using UnluCoProductCatalog.Application.ViewModels.EmailViewModels;

namespace UnluCoProductCatalog.Application.Interfaces.RabbitMQ
{
    public interface IPublisherService
    {
        void Publish(EmailToSend email, string queueName);
    }
}
