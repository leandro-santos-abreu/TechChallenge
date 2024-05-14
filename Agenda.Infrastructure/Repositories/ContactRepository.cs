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
    }
}
