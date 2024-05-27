using Agenda.Domain.Interfaces.Caches;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace Agenda.Infrastructure.Cache
{
    public class TokenCache(IMemoryCache cache, IConfiguration configuration) : ITokenCache
    {
        private readonly IMemoryCache _cache = cache;
        private readonly IConfiguration _configuration = configuration;

        private readonly string _cacheKey = "Token.";

        public async Task<string> GetOrCreateAsync(string userName, Func<Task<string>> retrieveDataFunc, TimeSpan? slidingExpiration = null)
        {
            if (!_cache.TryGetValue(_cacheKey + userName, out string cachedData))
            {
                cachedData = await retrieveDataFunc();

                // Set cache options
                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    SlidingExpiration = slidingExpiration ?? TimeSpan.FromMinutes(double.Parse(_configuration.GetRequiredSection("Cache:TokenCacheExpirationTime").Value!))
                };

                // Save data in cache
                _cache.Set(_cacheKey + userName, cachedData, cacheEntryOptions);
            }

            return cachedData;
        }
    }
}
