using StackExchange.Redis;
using System;
using System.Threading.Tasks;

namespace API_Best_Practice.Services
{
    public class RedisCacheService
    {
        private readonly IDatabase _cache;

        public RedisCacheService(IConnectionMultiplexer redis)
        {
            _cache = redis.GetDatabase();
        }

        public async Task SetCacheValueAsync(string key, string value, TimeSpan expiration)
        {
            await _cache.StringSetAsync(key, value, expiration);
        }

        public async Task<string?> GetCacheValueAsync(string key)
        {
            return await _cache.StringGetAsync(key);
        }
    }
} 