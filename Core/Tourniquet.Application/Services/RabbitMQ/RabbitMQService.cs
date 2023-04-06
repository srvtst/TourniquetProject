using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using Tourniquet.Application.Configuration.RabbitMQ;

namespace Tourniquet.Application.Services.RabbitMQ
{
    public class RabbitMQService : IRabbitMQService
    {
        private readonly IConfiguration _configuration;
        private readonly RabbitMQConfiguration _rabbitMQ;
        public RabbitMQService(IConfiguration configuration)
        {
            _configuration = configuration;
            _rabbitMQ = _configuration.GetSection("RabbitMQ").Get<RabbitMQConfiguration>();
        }

        public IConnection GetConnection()
        {
            ConnectionFactory connectionFactory = new()
            {
                Uri = _rabbitMQ.Uri
            };

            return connectionFactory.CreateConnection();
        }

        public IModel GetModel(IConnection connection)
        {
            return connection.CreateModel();
        }
    }
}