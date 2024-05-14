using Agenda.Domain.Entities;

namespace Agenda.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> FindByUserNameAsync(string username, CancellationToken ct);
    }
}
