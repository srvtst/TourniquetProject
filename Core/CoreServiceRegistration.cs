using CoreLayer.CrossCuttingConcerns.Caching.DistributedCache.Abstract;
using CoreLayer.CrossCuttingConcerns.Caching.DistributedCache.Concrete;
using CoreLayer.CrossCuttingConcerns.Caching.Microsoft.Abstract;
using CoreLayer.CrossCuttingConcerns.Caching.Microsoft.Concrete;
using CoreLayer.Security.Jwt;
using Microsoft.Extensions.DependencyInjection;

namespace CoreLayer
{
    public static class CoreServiceRegistration
    {
        public static IServiceCollection AddCoreService(this IServiceCollection services)
        {
            services.AddTransient<ITokenHelper,JwtHelper>();
            services.AddMemoryCache();
            services.AddScoped<ICacheManager, MemoryCacheManager>();
            services.AddSingleton<IRedisCacheConfiguration,RedisCacheConfigurationManager>();
            services.AddSingleton<IRedisCacheService, RedisCacheManager>();
            return services;
        }
    }
}