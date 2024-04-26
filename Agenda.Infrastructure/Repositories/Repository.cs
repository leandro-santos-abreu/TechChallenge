using Agenda.Domain;
using Agenda.Domain.Interfaces;
using Agenda.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Agenda.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DataContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>();
        }

        public virtual async Task<T?> DeleteAsync(Guid id, CancellationToken ct)
        {
            var entity = await FindByIdAsync(id, ct);

            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync(ct);
            }

            return entity;
        }

        public virtual async Task<T?> FindByIdAsync(Guid id, CancellationToken ct) =>
            await _dbSet.AsNoTracking().FirstOrDefaultAsync(entity => entity.Id == id, ct);

        public virtual async Task<IList<T>> GetAllAsync(CancellationToken ct) =>
            await _dbSet.AsNoTracking().ToListAsync(ct);

        public virtual async Task<T> SaveAsync(T entity, CancellationToken ct)
        {
            await _dbSet.AddAsync(entity, ct);
            await _context.SaveChangesAsync(ct);
            return entity;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
