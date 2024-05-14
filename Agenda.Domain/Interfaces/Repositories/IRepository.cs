using System.Linq.Expressions;

namespace Agenda.Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IList<T>> GetAllAsync(CancellationToken ct);
        Task<T?> FindByIdAsync(Guid id, CancellationToken ct);
        Task<T> SaveAsync(T entity, CancellationToken ct);
        Task<T> UpdateAsync(T entity);
        Task<T?> DeleteAsync(Guid id, CancellationToken ct);
    }
}
