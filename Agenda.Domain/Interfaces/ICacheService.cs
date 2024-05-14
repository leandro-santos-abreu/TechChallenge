namespace Agenda.Domain.Interfaces
{
    public interface ICacheService<T>
    {
        Task<T> GetOrCreateAsync(
            string cacheKey,
            Func<Task<T>> retrieveDataFunc,
            TimeSpan? slidingExpiration = null);
    }
}
