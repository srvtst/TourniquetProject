using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Text;
using Tourniquet.Domain;
using RabbitMQ.Client;

namespace Tourniquet.Application.Services.RabbitMQ
{
    public class PublisherService : IPublisherService
    {
        private readonly IRabbitMQService _rabbitMQService;
        ILogger<PublisherService> _logger;
        public PublisherService(IRabbitMQService rabbitMQService,ILogger<PublisherService> logger)
        {
            _rabbitMQService = rabbitMQService;
            _logger = logger;
        }

        public void Publish(Turnstile turnstile)
        {
            using var connection = _rabbitMQService.GetConnection();

            using var channel = connection.CreateModel();

            _logger.LogInformation("RabbitMQ ile bağlantı kuruldu.");

            channel.QueueDeclare(queue: "Turnstile",
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var body = JsonSerializer.Serialize(turnstile);

            var byteBody = Encoding.UTF8.GetBytes(body);

            var properties = channel.CreateBasicProperties();

            channel.BasicPublish(exchange: string.Empty,
                                 routingKey: "Turnstile",
                                 body: byteBody,
                                 basicProperties: properties);
        }
    }
}