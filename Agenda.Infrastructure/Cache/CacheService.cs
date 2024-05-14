using Agenda.Domain.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace Agenda.Infrastructure.Cache
{
    public class CacheService<T>(IMemoryCache cache, IConfiguration configuration) : ICacheService<T>
    {
        private readonly IMemoryCache _cache = cache;
        private readonly IConfiguration _configuration = configuration;
        public async Task<T> GetOrCreateAsync(
        string cacheKey,
        Func<Task<T>> retrieveDataFunc,
        TimeSpan? slidingExpiration = null)
        {
            if (!_cache.TryGetValue(cacheKey, out T cachedData))
            {
                cachedData = await retrieveDataFunc();

                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    SlidingExpiration = slidingExpiration ?? TimeSpan.FromMinutes(double.Parse(_configuration.GetRequiredSection("Cache:CacheServiceDefaultExpirationTime").Value!))
                };

                _cache.Set($"{typeof(T)}.{cacheKey}", cachedData, cacheEntryOptions);
            }

            return cachedData;
        }
    }
}
