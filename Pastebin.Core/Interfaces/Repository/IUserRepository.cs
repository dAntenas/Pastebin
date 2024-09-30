using Pastebin.Core.Models;

namespace Pastebin.Core.Interfaces.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        public User GetByEmail(string email);

        public Task<User> GetByEmailAsync(string email);
    }
}
