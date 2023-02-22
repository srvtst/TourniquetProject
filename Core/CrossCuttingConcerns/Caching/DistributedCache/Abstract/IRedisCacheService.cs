namespace CoreLayer.CrossCuttingConcerns.Caching.DistributedCache.Abstract
{
    public interface IRedisCacheService
    {
        void SetCache(string key, string value, int db, int duration);
        bool IsKeyDb(string key, int db);
    }
}