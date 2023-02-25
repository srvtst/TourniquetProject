namespace CoreLayer.CrossCuttingConcerns.Caching.DistributedCache.Abstract
{
    public interface IRedisCacheService
    {
        T GetCache<T>(string key, int db);
        List<T> GetListCache<T>(string key, int db);
        void SetCache(string key, string value, int db, int duration);
        bool IsKeyDb(string key, int db);
        void RemoveCache<T>(string key, int db);
    }
}