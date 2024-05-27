using Agenda.Domain.Entities;
using Agenda.Domain.Interfaces;
using Agenda.Domain.Interfaces.Repositories;
using Agenda.Infrastructure.Repositories;

namespace Agenda.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;
        private IUserRepository _userRepository;
        private IContactRepository _contactRepository;
        private IRepository<PhoneNumber> _phoneNumberRepository;
        private IRepository<LogEntity> _logsRepository;

        public UnitOfWork(DataContext context)
        {
            _dataContext = context;
            _userRepository = new UserRepository(_dataContext);
            _contactRepository = new ContactRepository(_dataContext);
            _phoneNumberRepository = new Repository<PhoneNumber>(_dataContext);
            _logsRepository = new Repository<LogEntity>(_dataContext);
        }

        public IUserRepository Users => _userRepository;
        public IContactRepository Contacts => _contactRepository;
        public IRepository<PhoneNumber> PhoneNumbers => _phoneNumberRepository;
        public IRepository<LogEntity> Logs => _logsRepository;

        public async Task CompleteAsync(CancellationToken ct)
        {
            await _dataContext.SaveChangesAsync(ct);
        }

        public void Dispose()
        {
            _dataContext.Dispose();
        }
    }
}
