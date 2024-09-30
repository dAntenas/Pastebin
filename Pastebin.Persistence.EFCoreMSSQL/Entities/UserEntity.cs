using Pastebin.Core.Interfaces.Entity;

namespace Pastebin.Persistence.EFCoreMSSQL.Entities
{
    internal class UserEntity : IEntity
    {
        public Guid Id { get; set; }

        public string Username { get; private set; }

        public string PasswordHash { get; private set; }

        public string Email { get; private set; }
    }
}
