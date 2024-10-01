using System.ComponentModel.DataAnnotations;

namespace Pastebin.API.Contracts.User
{
    internal record LoginUserRequest(
        [Required] string Email,
        [Required] string Password
        );
}
