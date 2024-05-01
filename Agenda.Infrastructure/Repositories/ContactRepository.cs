using Agenda.Domain.Entities;
using Agenda.Domain.Interfaces;
using Agenda.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Infrastructure.Repositories
{
    public class ContactRepository(DataContext context) : Repository<Contact>(context), IContactRepository
    {
        public override async Task<Contact?> FindByIdAsync(Guid id, CancellationToken ct) =>
            await _context.Contacts.AsNoTracking().Include(c => c.PhoneNumbers).ThenInclude(p => p.AreaCode).FirstOrDefaultAsync(entity => entity.Id == id, ct);

        public override async Task<IList<Contact>> GetAllAsync(CancellationToken ct) =>
            await _context.Contacts.AsNoTracking().Include(c => c.PhoneNumbers).ThenInclude(p => p.AreaCodeEntity).AsNoTracking().ToListAsync(ct);
    }
}
