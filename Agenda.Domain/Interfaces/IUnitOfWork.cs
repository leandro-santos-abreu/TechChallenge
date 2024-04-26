namespace Agenda.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        Task CompleteAsync(CancellationToken ct);
    }
}
