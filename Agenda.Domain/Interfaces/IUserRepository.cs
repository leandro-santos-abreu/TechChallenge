using Agenda.Domain.Entities;

namespace Agenda.Domain.Interfaces
{
    public interface IUserRepository: IRepository<User>
    {
        Task<User> FindByUserNameAsync(string username, CancellationToken ct);
    }
}
