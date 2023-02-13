using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer
{
    public static class DataAccessServiceRegistration
    {
        public static IServiceCollection AddDataAccessService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TourniquetContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("PostgreSql"));
            });

            services.AddTransient<IPersonDal, EFPersonDal>();
            services.AddTransient<ITourniquetDal, EFTourniquetDal>();
            return services;
        }
    }
}