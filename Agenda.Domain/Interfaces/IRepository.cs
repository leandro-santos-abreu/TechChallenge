﻿namespace Agenda.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IList<T>> GetAllAsync(CancellationToken ct);
        Task<T?> FindByIdAsync(Guid id, CancellationToken ct);
        Task<T> SaveAsync(T entity, CancellationToken ct);
        Task<T> UpdateAsync(T entity, CancellationToken ct);
        Task<T?> DeleteAsync(Guid id, CancellationToken ct);
    }
}