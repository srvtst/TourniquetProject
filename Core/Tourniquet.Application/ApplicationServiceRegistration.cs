using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Tourniquet.Application.Features.Auth.Rules;
using Tourniquet.Application.Features.Validations;
using Tourniquet.Application.Services.Auth;
using Tourniquet.Application.Services.Cache;
using Tourniquet.Application.Services.Mail;
using Tourniquet.Application.Services.RabbitMQ;
using Tourniquet.Application.Services.Redis;
using Tourniquet.Persistence.Repositories.Redis;

namespace Tourniquet.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IMailSender,MailSender>();
            services.AddTransient<IRabbitMQService,RabbitMQService>();
            services.AddTransient<IPublisherService, PublisherService>();
            services.AddTransient<IConsumerService, ConsumerService>();
            services.AddScoped<ICacheService, CacheService>();
            services.AddScoped<IRedisServiceConfiguration,RedisServiceConfiguration>();
            services.AddTransient(typeof(AuthBusinessRules));
            return services;
        }
    }
}