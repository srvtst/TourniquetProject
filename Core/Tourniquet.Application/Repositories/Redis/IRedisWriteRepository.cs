namespace Tourniquet.Application.Repositories.Redis
{
    public interface IRedisWriteRepository
    {
        Task Add(string key, int name, string value, int db);
        Task Delete(string key, int name, int db);
    }
}