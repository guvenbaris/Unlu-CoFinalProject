using System;
using UnluCoProductCatalog.Application.Enums;
using UnluCoProductCatalog.Application.Interfaces.LogInterfaces;
using UnluCoProductCatalog.Application.Interfaces.RabbitMQ;
using UnluCoProductCatalog.Application.ViewModels.EmailViewModels;

namespace UnluCoProductCatalog.Persistence.Services.LogService
{
    public class EmailLoggerService : ILoggerService
    {
        private readonly IPublisherService _publisherService;

        public EmailLoggerService(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }
        public void Log(string message)
        {
            var email = new EmailToSend()
            {
                To = "........@gmail.com",
                Subject = "User Gestures",
                Body = message,
            };
            Console.WriteLine("Emaile Loglandı");
            _publisherService.Publish(email, RabbitMqQueue.EmailSenderQueue.ToString());
        }
    }
}
