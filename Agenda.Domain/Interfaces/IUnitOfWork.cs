using Agenda.Domain.Entities;
using Agenda.Domain.Interfaces.Repositories;

namespace Agenda.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IRepository<Contact> Contacts { get; }
        IRepository<LogEntity> Logs { get; }
        Task CompleteAsync(CancellationToken ct);
    }
}
