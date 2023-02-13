using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.Mailing.Abstract;
using BusinessLayer.Mailing.Concrete;
using BusinessLayer.MessageBroker.RabbitMQ.Abstract;
using BusinessLayer.MessageBroker.RabbitMQ.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLayer
{
    public static class BusinessServicesRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddTransient<IPersonService, PersonManager>();
            services.AddTransient<ITourniquetService, TourniquetManager>();
            services.AddTransient<IAuthService, AuthManager>();
            services.AddTransient<IMailSender, MailSenderManager>();
            services.AddTransient<IRabbitMQService, RabbitMQManager>();
            services.AddTransient<IPublisherService, PublisherManager>();
            services.AddTransient<IConsumerService, ConsumerManager>();
            return services;
        }
    }
}