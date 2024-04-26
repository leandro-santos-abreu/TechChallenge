using Agenda.Domain.Interfaces;
using Agenda.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Agenda.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;
        private IUserRepository _userRepository;

        public UnitOfWork(DataContext context)
        {
            _dataContext = context;
            _userRepository = new UserRepository(_dataContext); // Inject DataContext into UserRepository
        }

        public IUserRepository Users => _userRepository;

        public async Task CompleteAsync(CancellationToken ct)
        {
            await _dataContext.SaveChangesAsync(ct);
        }

        public void Dispose()
        {
            _dataContext.Dispose(); // Dispose DataContext when UnitOfWork is disposed
        }
    }
}
