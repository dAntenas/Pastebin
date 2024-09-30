using Microsoft.EntityFrameworkCore;
using Pastebin.Core.Interfaces.Repository;
using Pastebin.Core.Models;
using System.Collections.Immutable;

namespace Pastebin.Persistence.EFCoreMSSQL.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly PastebinDbContext _pastebinDbContext;

        public UserRepository(PastebinDbContext pastebinDbContext)
        {
            _pastebinDbContext = pastebinDbContext;
        }

        public void Add(User item)
        {
            //_pastebinDbContext.Users.Add(item);
            //_pastebinDbContext.SaveChanges();
        }

        public async Task AddAsync(User item, CancellationToken cancel = default)
        {
            //await _pastebinDbContext.Users.AddAsync(item);
            //await _pastebinDbContext.SaveChangesAsync(cancel).ConfigureAwait(false);
        }

        public IReadOnlyCollection<User> Get()
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyCollection<User>> GetAsync(CancellationToken cancel = default)
        {
            //return _pastebinDbContext.Users.ToImmutableArray();
            throw new NotImplementedException();
        }

        public User GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            var userByEmail = await _pastebinDbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email) ?? throw new Exception()
                ;

            throw new NotImplementedException();

            //return userByEmail;
        }

        public User GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetByIdAsync(Guid id, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAsync(Guid id, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }

        public void Update(User item)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(User item, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }
    }
}
