using Agenda.Domain;
using Agenda.Domain.Interfaces;
using Agenda.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected DataContext _dataContext;
        protected DbSet<T> _dbSet;

        public Repository(DataContext dataContext)
        {
            _dataContext = dataContext;
            _dbSet = _dataContext.Set<T>();
        }

        public async Task<T?> DeleteAsync(Guid id, CancellationToken ct)
        {
            var entity = await FindByIdAsync(id, ct);
           
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _dataContext.SaveChangesAsync(ct);
            }

            return entity;
        }

        public async Task<T?> FindByIdAsync(Guid id, CancellationToken ct) => await _dbSet.FirstOrDefaultAsync(entity => entity.Id == id, ct);

        public async Task<IList<T>> GetAllAsync(CancellationToken ct) => await _dbSet.ToListAsync(ct);

        public async Task<T> SaveAsync(T entity, CancellationToken ct)
        {
            await _dbSet.AddAsync(entity, ct);
            await _dataContext.SaveChangesAsync(ct);
            return entity;
        }

        public async Task<T> UpdateAsync(T entity, CancellationToken ct)
        {
            _dbSet.Update(entity);
            await _dataContext.SaveChangesAsync(ct);

            return entity;
        }
    }
}
