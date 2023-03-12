namespace Tourniquet.Application.Repositories.Redis
{
    public interface IRedisReadRepository
    {
        bool CacheKeyExists(string key, int db);
        Task<T> GetById<T>(string key, int id, int db);
        Task<IList<T>> GetAll<T>(string key, int db);
    }
}