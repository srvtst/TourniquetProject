namespace Tourniquet.Application.Repositories.Redis
{
    public interface IRedisReadRepository
    {
        Task<T> GetById<T>(string key, int id, int db);
        Task<IList<T>> GetAll<T>(string key, int db);
    }
}