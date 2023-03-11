using System.Text.Json;
using Tourniquet.Application.Repositories.Redis;
using Tourniquet.Application.Services.Redis;

namespace Tourniquet.Persistence.Repositories.Redis
{
    public class ReadRedisRepository : IRedisReadRepository
    {
        private IRedisServiceConfiguration _redisService;
        public ReadRedisRepository(IRedisServiceConfiguration redisService)
        {
            _redisService = redisService;
            _redisService.Connect();
        }

        public bool CacheKeyExists(string key, int db)
        {
            var database = _redisService.Get(db);
            if (database.KeyExists(key))
            {
                return true;
            }
            return false;
        }

        public async Task<T> GetById<T>(string key, int id, int db)
        {
            var database = _redisService.Get(db);
            if (CacheKeyExists(key, db))
            {
                var cache = await database.HashGetAsync(key, id);
                var result = JsonSerializer.Deserialize<T>(cache);
                return result;
            }
            throw new Exception("redisten gelmedi");
        }

        public async Task<IList<T>> GetAll<T>(string key, int db)
        {
            var database = _redisService.Get(db);
            var result = new List<T>();
            if (CacheKeyExists(key, db))
            {
                var cache = await database.HashGetAllAsync(key);
                foreach (var item in cache.ToList())
                {
                    var cacheItem = JsonSerializer.Deserialize<T>(item.Value);
                    result.Add(cacheItem);
                }
                return result;
            }
            throw new Exception("redisten gelmedi");
        }
    }
}