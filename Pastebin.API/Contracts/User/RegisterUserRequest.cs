using System.ComponentModel.DataAnnotations;

namespace Pastebin.API.Contracts.User
{
    internal record RegisterUserRequest(
        [Required] string Username,
        [Required] string Password,
        [Required] string Email
        );
}
