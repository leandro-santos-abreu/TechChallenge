using Agenda.Domain.Entities;
using Agenda.Domain.Interfaces.Repositories;
using Agenda.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Infrastructure.Repositories
{
    public class UserRepository(DataContext context) : Repository<User>(context), IUserRepository
    {
        /// <summary>
        /// Method responsible for saving an User entity in the database.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public override async Task<User> SaveAsync(User entity, CancellationToken ct)
        {
            entity.Password = System.Web.Helpers.Crypto.HashPassword(entity.Password);
            return await base.SaveAsync(entity, ct);
        }

        /// <summary>
        /// Method responsible for retrieving a specific User stored in the database using It's User Name.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public async Task<User> FindByUserNameAsync(string username, CancellationToken ct)
        {
            return (await _context.Users.AsNoTracking()
                .FirstOrDefaultAsync(u => u.UserName == username, ct))!;
        }
    }
}
