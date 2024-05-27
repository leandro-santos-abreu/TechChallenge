using Agenda.Domain;
using Agenda.Domain.Interfaces.Repositories;
using Agenda.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

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

        /// <summary>
        /// Method responsible for deleting a specific entity stored in the database using It's GUID.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public virtual async Task<T?> DeleteAsync(Guid id, CancellationToken ct)
        {
            var entity = await FindByIdAsync(id, ct);

            if (entity != null)
                _dbSet.Remove(entity);

            return entity;
        }

        /// <summary>
        /// Method responsible for retrieving a specific entity stored in the database using It's GUID.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public virtual async Task<T?> FindByIdAsync(Guid id, CancellationToken ct) =>
            await _dbSet.AsNoTracking().FirstOrDefaultAsync(entity => entity.Id == id, ct);

        /// <summary>
        /// Method responsible for retrieving all entities of a set stored in the database.
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        public virtual async Task<IList<T>> GetAllAsync(CancellationToken ct) =>
            await _dbSet.AsNoTracking().ToListAsync(ct);

        /// <summary>
        /// Method responsible for saving a specific entity stored in the database.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public virtual async Task<T> SaveAsync(T entity, CancellationToken ct)
        {
            await _dbSet.AddAsync(entity, ct);
            return entity;
        }

        /// <summary>
        /// Method responsible for updating a specific entity stored in the database.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            return entity;
        }
    }
}
