using System;
using System.Net.Mail;
using System.Text;
using System.Text.Json;
using System.Threading;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using UnluCoProductCatalog.Application.Interfaces.Mail;
using UnluCoProductCatalog.Application.Interfaces.RabbitMQ;
using UnluCoProductCatalog.Application.ViewModels.EmailViewModels;

namespace UnluCoProductCatalog.ConsoleConsumer
{
    public class Consumer
    {
        private readonly IRabbitMqService _rabbitMqService;
        private readonly ISmtpServer _smtpServer;
        public event EventHandler<EmailToSend> MessageReceived;

        public Consumer(IRabbitMqService rabbitMqService, ISmtpServer smtpServer)
        {
            _rabbitMqService = rabbitMqService;
            _smtpServer = smtpServer;
        }

        public void Start(string queue)
        {
            var connection = _rabbitMqService.GetRabbitMqConnection();

            var channel = connection.CreateModel();

            channel.QueueDeclare(queue, false, false, false, null);
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += async (ch, ea) =>
            {
                var message = JsonSerializer.Deserialize<EmailToSend>(Encoding.UTF8.GetString(ea.Body.ToArray()));
                MessageReceived?.Invoke(this, message);
                using var client = _smtpServer.GetSmtpClient();
                try
                {
                    var mailMessage = new MailMessage
                    {
                        Body = message.Body,
                        From = new MailAddress(message.From),
                        Subject = message.Subject,

                    };
                    mailMessage.To.Add(message.To);

                    await client.SendMailAsync(mailMessage);
                    Thread.Sleep(1000);

                }
                catch (Exception e)
                {
                    throw new InvalidOperationException(e.Message);
                }
                finally
                {
                    client.Dispose();
                }
            };
            channel.BasicConsume(queue, true, consumer: consumer);
        }

    }
}
