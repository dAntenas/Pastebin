using Pastebin.Application.Interfaces.Authentication;
using Pastebin.Core.Interfaces.Repository;
using Pastebin.Core.Models;

namespace Pastebin.Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtProvider _jwtProvider;

        public UserService(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtProvider jwtProvider)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtProvider = jwtProvider;
        }

        public async Task<IReadOnlyCollection<User>> GetUsersAsync()
        {
            return await _userRepository.GetAsync();
        }

        public async Task Register(string userName, string email, string password)
        {
            var hashedPassword = _passwordHasher.Generate(password);

            var newUser = User.Create(Guid.NewGuid(), userName, hashedPassword, email);

            await _userRepository.AddAsync(newUser);
        }

        public async Task<string> Login(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email);

            var result = _passwordHasher.Verify(password, user.PasswordHash);

            if (!result)
            {
                throw new Exception();
            }

            var token = _jwtProvider.GenerateToken(user);

            return token;
        }
    }
}
