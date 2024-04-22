using Agenda.Domain.Entities;
using Agenda.Domain.Services;
using Agenda.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Infrastructure.Repositories
{
    public class ContactRepository(DataContext dataContext) : IContactRepository
    {
        private readonly DataContext _dataContext = dataContext;

        public async Task<ICollection<Contact>> GetAllContacts(CancellationToken ct)
        {
            return await _dataContext.Contacts.ToListAsync(ct);
        }

        public async Task<Contact?> GetContactById(Guid id, CancellationToken ct)
        {
            return await _dataContext.Contacts.SingleOrDefaultAsync(c => c.Id == id, ct);
        }

        public async Task<Contact> SaveContact(Contact entity, CancellationToken ct)
        {
            var entityTracker = await _dataContext.Contacts.AddAsync(entity, ct);
            await _dataContext.SaveChangesAsync(ct);
            return entityTracker.Entity;
        }

        public async Task<Contact?> UpdateContactById(Guid id, Contact entity, CancellationToken ct)
        {
            var existingEntity = await GetContactById(id, ct);

            if (existingEntity != null)
            {
                _dataContext.Entry(existingEntity).CurrentValues.SetValues(entity);

                await _dataContext.SaveChangesAsync(ct);
            }

            return existingEntity;
        }

        public async Task<Contact?> DeleteContactById(Guid id, CancellationToken ct)
        {
            var entityToRemove = await GetContactById(id, ct);

            if (entityToRemove != null)
            {
                _dataContext.Contacts.Remove(entityToRemove);

                await _dataContext.SaveChangesAsync(ct);

                return entityToRemove; 
            }

            return null;
        }
    }
}
