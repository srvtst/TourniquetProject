using CoreLayer.CrossCuttingConcerns.Caching.DistributedCache.Abstract;
using System.Text.Json;

namespace CoreLayer.CrossCuttingConcerns.Caching.DistributedCache.Concrete
{
    public class RedisCacheManager : IRedisCacheService
    {
        IRedisCacheConfiguration _redisConfiguration;

        public RedisCacheManager(IRedisCacheConfiguration redisConfiguration)
        {
            _redisConfiguration = redisConfiguration;
        }

        public void SetCache(string key, string value, int db, int duration)
        {
            _redisConfiguration.Connect();
            var database = _redisConfiguration.Get(db);
            database.ListLeftPush(key, value);
            database.KeyExpire(key, DateTime.Now.AddMinutes(duration));
        }

        public bool IsKeyDb(string key, int db)
        {
            _redisConfiguration.Connect();
            var database = _redisConfiguration.Get(db);
            if (database.KeyExists(key))
            {
                return true;
            }
            return false;
        }
    }
}