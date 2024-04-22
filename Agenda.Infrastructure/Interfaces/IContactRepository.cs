using Agenda.Domain.Entities;

namespace Agenda.Domain.Services
{
    public interface IContactRepository
    {
        Task<ICollection<Contact>> GetAllContacts(CancellationToken ct);
        Task<Contact?> GetContactById(Guid id, CancellationToken ct);
        Task<Contact> SaveContact(Contact entity, CancellationToken ct);
        Task<Contact?> UpdateContactById(Guid id, Contact entity, CancellationToken ct);
        Task<Contact?> DeleteContactById(Guid id, CancellationToken ct);
    }
}
