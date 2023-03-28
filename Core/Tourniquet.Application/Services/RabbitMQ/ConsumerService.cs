using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using Tourniquet.Application.Services.Mail;

namespace Tourniquet.Application.Services.RabbitMQ
{
    public class ConsumerService : IConsumerService
    {
        private readonly IRabbitMQService _rabbitmqService;
        private readonly IMailSender _mailSender;
        public ConsumerService(IRabbitMQService rabbitmqService, IMailSender mailSender)
        {
            _rabbitmqService = rabbitmqService;
            _mailSender = mailSender;
        }

        public void Start()
        {
            using var connection = _rabbitmqService.GetConnection();

            using var channel = _rabbitmqService.GetModel(connection);

            var consumer = new EventingBasicConsumer(channel);

            channel.BasicConsume("Turnstile", false, consumer);

            consumer.Received += (object sender, BasicDeliverEventArgs e) =>
            {
                var message = Encoding.UTF8.GetString(e.Body.ToArray());
                channel.BasicAck(e.DeliveryTag, false);
            };

           //_mailSender.SendMail("servet.soysal@hotmail.com", "Consumer başarılı olarak okuma yaptı.");
        }
    }
}