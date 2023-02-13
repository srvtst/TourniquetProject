using RabbitMQ.Client;

namespace BusinessLayer.MessageBroker.RabbitMQ.Abstract
{
    public interface IRabbitMQService
    {
        IConnection GetConnection();
        IModel GetModel(IConnection connection);
    }
}