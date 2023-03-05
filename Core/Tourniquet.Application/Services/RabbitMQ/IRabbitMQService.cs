using RabbitMQ.Client;

namespace Tourniquet.Application.Services.RabbitMQ
{
    public interface IRabbitMQService
    {
        IConnection GetConnection();
        IModel GetModel(IConnection connection);
    }
}