using StackExchange.Redis;

namespace Tourniquet.Application.Services.Redis
{
    public interface IRedisServiceConfiguration
    {
        void Connect();
        IDatabase Get(int db);
    }
}