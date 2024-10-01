using Pastebin.Core.Models;

namespace Pastebin.Application.Interfaces.Authentication
{
    public interface IJwtProvider
    {
        public string GenerateToken(User user);
    }
}
