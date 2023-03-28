using Tourniquet.Domain.Entities;

namespace Tourniquet.Application.Services.RabbitMQ
{
    public interface IPublisherService
    {
        void Publish(Turnstile turnstile);
    }
}