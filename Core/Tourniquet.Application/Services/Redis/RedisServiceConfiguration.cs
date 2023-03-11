using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using Tourniquet.Application.Dtos.Redis;
using Tourniquet.Application.Services.Redis;

namespace Tourniquet.Persistence.Repositories.Redis
{
    public class RedisServiceConfiguration : IRedisServiceConfiguration
    {
        private ConnectionMultiplexer _redis;
        private IConfiguration _configuration;
        private RedisSettings _redisSettings;

        public RedisServiceConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
            _redisSettings = _configuration.GetSection("RedisSettings").Get<RedisSettings>();
        }

        public void Connect()
        {
            string config = $"{_redisSettings.Host}:{_redisSettings.Port}";
            _redis = ConnectionMultiplexer.Connect(config);
        }

        public IDatabase Get(int db)
        {
            return _redis.GetDatabase(db);
        }
    }
}