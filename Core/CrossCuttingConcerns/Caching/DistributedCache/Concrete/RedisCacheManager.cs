using CoreLayer.CrossCuttingConcerns.Caching.DistributedCache.Abstract;
using System.Text.Json;

namespace CoreLayer.CrossCuttingConcerns.Caching.DistributedCache.Concrete
{
    public class RedisCacheManager : IRedisCacheService
    {
        private readonly IRedisCacheConfiguration _redisConfiguration;

        public RedisCacheManager(IRedisCacheConfiguration redisConfiguration)
        {
            _redisConfiguration = redisConfiguration;
            _redisConfiguration.Connect();
        }

        public void SetCache(string key, string value, int db, int duration)
        {
            var database = _redisConfiguration.Get(db);
            database.ListLeftPush(key, value);
            database.KeyExpire(key, DateTime.Now.AddMinutes(duration));
        }

        public bool IsKeyDb(string key, int db)
        {
            var database = _redisConfiguration.Get(db);
            if (database.KeyExists(key))
            {
                return true;
            }
            return false;
        }

        public List<T> GetListCache<T>(string key, int db)
        {
            var result = new List<T>();
            var database = _redisConfiguration.Get(db);
            var cacheList = database.ListRange(key);
            foreach (var item in cacheList)
            {
                result = JsonSerializer.Deserialize<List<T>>(item);
            }
            return result;
        }

        public T GetCache<T>(string key, int db)
        {
            var database = _redisConfiguration.Get(db);
            var cacheList = database.ListRange(key).First();
            var result = JsonSerializer.Deserialize<T>(cacheList.ToString());
            return result;
        }

        public void RemoveCache<T>(string key, int db)
        {
            var database = _redisConfiguration.Get(db);
            var productList = GetListCache<T>(key, db);
            database.ListRemove(key, JsonSerializer.Serialize(productList));
        }
    }
}