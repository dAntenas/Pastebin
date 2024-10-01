using Pastebin.API.Contracts.User;
using Pastebin.Application.Services;

namespace Pastebin.API.Endpoints
{
    internal static class UserEndpoints
    {
        public static IEndpointRouteBuilder MapUserEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            endpointRouteBuilder.MapPost("register", Register);

            endpointRouteBuilder.MapPost("login", Login);

            endpointRouteBuilder.MapGet("users", GetUsers).RequireAuthorization();

            return endpointRouteBuilder;
        }

        private static async Task<IResult> GetUsers(
            UserService userService
            )
        {
            var result = await userService.GetUsersAsync();
            return Results.Ok(result);
        }

        private static async Task<IResult> Login(
            LoginUserRequest loginUserRequest,
            UserService userService
            )
        {
            var token = await userService.Login(
                loginUserRequest.Email,
                loginUserRequest.Password
                );

            return Results.Ok(token);
        }

        private static async Task<IResult> Register(
            RegisterUserRequest registerUserRequest,
            UserService userService
            )
        {
            await userService.Register(
                registerUserRequest.Username,
                registerUserRequest.Email,
                registerUserRequest.Password
                );

            return Results.Ok();
        }
    }
}
