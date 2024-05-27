using Agenda.Domain.Entities;

namespace Agenda.Domain.Interfaces.Repositories
{
    public interface IContactRepository : IRepository<Contact>
    {
        Task<IList<Contact>> GetAllByAreaCode(string ddd, CancellationToken ct);
    }
}
