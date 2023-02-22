using StackExchange.Redis;

namespace CoreLayer.CrossCuttingConcerns.Caching.DistributedCache.Abstract
{
    public interface IRedisCacheConfiguration
    {
        public void Connect();
        public IDatabase Get(int db);
    }
}