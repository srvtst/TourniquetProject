using Tourniquet.Application.Repositories.Redis;
using Tourniquet.Application.Services.Redis;

namespace Tourniquet.Persistence.Repositories.Redis
{
    public class WriteRedisRepository : IRedisWriteRepository
    {
        private IRedisServiceConfiguration _redisService;
        public WriteRedisRepository(IRedisServiceConfiguration redisService)
        {
            _redisService = redisService;
            _redisService.Connect();
        }

        public async Task Add(string key, int name, string value, int db)
        {
            var database = _redisService.Get(db);
            await database.HashSetAsync(key, name, value);
        }

        public async Task Delete(string key, int name, int db)
        {
            var database = _redisService.Get(db);
            await database.HashDeleteAsync(key, name);
        }
    }
}