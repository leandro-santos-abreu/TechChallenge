﻿using Agenda.Domain.Entities;
using Agenda.Domain.Interfaces;
using Agenda.Infrastructure.Repositories;

namespace Agenda.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;
        private IUserRepository _userRepository;
        private IContactRepository _contactRepository;
        private IRepository<PhoneNumber> _phoneNumberRepository;

        public UnitOfWork(DataContext context)
        {
            _dataContext = context;
            _userRepository = new UserRepository(_dataContext);
            _contactRepository = new ContactRepository(_dataContext);
            _phoneNumberRepository = new Repository<PhoneNumber>(_dataContext);
        }

        public IUserRepository Users => _userRepository;

        public IRepository<Contact> Contacts => _contactRepository;
        public IRepository<PhoneNumber> PhoneNumbers => _phoneNumberRepository;

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
