using Agenda.Domain.Entities;

namespace Agenda.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IRepository<Contact> Contacts { get; }
        Task CompleteAsync(CancellationToken ct);
    }
}
