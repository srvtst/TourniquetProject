namespace Tourniquet.Application.Services.Cache
{
    public interface ICacheService
    {
        T Get<T>(string key);
        object Get(string key);
        void Remove(string key);
        void Add(string key, object value, int duration);
        bool IsThere(string key);
    }
}