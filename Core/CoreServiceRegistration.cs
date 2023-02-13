using CoreLayer.CrossCuttingConcerns.Caching.Abstract;
using CoreLayer.CrossCuttingConcerns.Caching.Concrete;
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
            return services;
        }
    }
}