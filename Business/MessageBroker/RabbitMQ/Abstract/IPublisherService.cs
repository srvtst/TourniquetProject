using EntitiesLayer.Concrete;

namespace BusinessLayer.MessageBroker.RabbitMQ.Abstract
{
    public interface IPublisherService
    {
        void Publish(Tourniquet tourniquet);
    }
}