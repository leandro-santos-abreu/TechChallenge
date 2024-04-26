﻿using Agenda.Domain.Entities;
using Agenda.Domain.Interfaces;
using Agenda.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Agenda.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {
        }

        public override async Task<User> SaveAsync(User entity, CancellationToken ct)
        {
            entity.Password = System.Web.Helpers.Crypto.HashPassword(entity.Password);
            return await base.SaveAsync(entity, ct);
        }

        public async Task<User> FindByUserNameAsync(string username, CancellationToken ct)
        {
            return (await _context.Users.AsNoTracking()
                .FirstOrDefaultAsync(u => u.UserName == username, ct))!;
        }
    }
}