using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tourniquet.Application.Repositories;
using Tourniquet.Application.Repositories.Redis;
using Tourniquet.Application.Repositories.Tourniquet;
using Tourniquet.Persistence.Context;
using Tourniquet.Persistence.Repositories;
using Tourniquet.Persistence.Repositories.Redis;
using Tourniquet.Persistence.Repositories.Tourniquet;

namespace Tourniquet.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TurnstileDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("PostgreSql"));
            });

            services.AddScoped<IPersonReadRepository, PersonReadRepository>();
            services.AddScoped<IPersonWriteRepository, PersonWriteRepository>();
            services.AddScoped<ITurnstileReadRepository, TurnstileReadRepository>();
            services.AddScoped<ITurnstileWriteRepository, TurnstileWriteRepository>();
            services.AddScoped<IRedisReadRepository, ReadRedisRepository>();
            services.AddScoped<IRedisWriteRepository, WriteRedisRepository>();
            return services;
        }
    }
}