using Agenda.Domain.Entities;
using Agenda.Domain.Interfaces.Repositories;
using Agenda.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Infrastructure.Repositories
{
    public class ContactRepository(DataContext context) : Repository<Contact>(context), IContactRepository
    {
        /// <summary>
        /// Method responsible for retrieving a specific Contact stored in the database using It's GUID.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public override async Task<Contact?> FindByIdAsync(Guid id, CancellationToken ct) =>
            await _context.Contacts.AsNoTracking().Include(c => c.PhoneNumbers).ThenInclude(p => p.AreaCode).FirstOrDefaultAsync(entity => entity.Id == id, ct);

        /// <summary>
        ///  Method responsible for retrieving all Contacts stored in the database.
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        public override async Task<IList<Contact>> GetAllAsync(CancellationToken ct) =>
            await _context.Contacts.AsNoTracking().Include(c => c.PhoneNumbers).ThenInclude(p => p.AreaCodeEntity).AsNoTracking().ToListAsync(ct);

        /// <summary>
        ///  Method responsible for retrieving all Contacts Stored in the Database From a Specific Area Code.
        /// </summary>
        /// <param name="areaCode"></param>
        /// <param name="ct"></param>
        /// <returns></returns>

        public async Task<IList<Contact>> GetAllByAreaCode(string areaCode, CancellationToken ct) =>
            await _context.Contacts.AsNoTracking().Include(c => c.PhoneNumbers).ThenInclude(p => p.AreaCodeEntity).AsNoTracking().Where(c => c.PhoneNumbers.Select(x => x.AreaCode).Contains(ddd)).ToListAsync(ct);

        /// <summary>
        ///  Method responsible for saving a Contacts in the Database.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public override async Task<Contact> SaveAsync(Contact entity, CancellationToken ct)
        {
            var savedEntity = await _context.Contacts.AddAsync(entity, ct);
            _context.SaveChanges();

            return await _context.Contacts.AsNoTracking().Include(c => c.PhoneNumbers).ThenInclude(p => p.AreaCodeEntity).AsNoTracking().FirstOrDefaultAsync(f => f.Id == savedEntity.Entity.Id, cancellationToken: ct);
        }
    }
}
