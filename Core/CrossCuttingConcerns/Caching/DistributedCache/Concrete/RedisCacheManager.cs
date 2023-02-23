using CoreLayer.CrossCuttingConcerns.Caching.DistributedCache.Abstract;
using Newtonsoft.Json;

namespace CoreLayer.CrossCuttingConcerns.Caching.DistributedCache.Concrete
{
    public class RedisCacheManager : IRedisCacheService
    {
        IRedisCacheConfiguration _redisConfiguration;

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
            List<T> result = new List<T>();
            var database = _redisConfiguration.Get(db);
            var cacheList = database.ListRange(key);
            foreach (var item in cacheList)
            {
                result = JsonConvert.DeserializeObject<List<T>>(item.ToString());
            }
            return result;
        }

        public T GetCache<T>(string key, int db)
        {
            var database = _redisConfiguration.Get(db);
            var cacheList = database.ListRange(key).First();
            var result = JsonConvert.DeserializeObject<T>(cacheList.ToString());
            return result;
        }

        public void RemoveCache(string key, int db)
        {
            throw new NotImplementedException();
        }
    }
}