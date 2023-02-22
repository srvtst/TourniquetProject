using CoreLayer.CrossCuttingConcerns.Caching.DistributedCache.Abstract;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;

namespace CoreLayer.CrossCuttingConcerns.Caching.DistributedCache.Concrete
{
    public class RedisCacheConfigurationManager : IRedisCacheConfiguration
    {
        private ConnectionMultiplexer _redis;
        private IConfiguration _configuration;
        private RedisSettings _redisSettings;

        public RedisCacheConfigurationManager(IConfiguration configuration)
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