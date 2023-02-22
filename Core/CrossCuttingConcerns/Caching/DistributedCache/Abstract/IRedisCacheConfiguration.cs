using StackExchange.Redis;

namespace CoreLayer.CrossCuttingConcerns.Caching.DistributedCache.Abstract
{
    public interface IRedisCacheConfiguration
    {
        void Connect();
        IDatabase Get(int db);
    }
}