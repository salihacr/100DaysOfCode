using StackExchange.Redis;

namespace Redis
{
    public class RedisService
    {
        ConnectionMultiplexer connectionMultiplexer;
        public void Connect() => connectionMultiplexer = ConnectionMultiplexer.Connect("localhost:6379");
        public IDatabase GetDb(int db) => connectionMultiplexer.GetDatabase(db);
    }
}
