using Pastebin.API.Extensions;
using Pastebin.Application.Interfaces.Authentication;
using Pastebin.Application.Services;
using Pastebin.Core.Interfaces.Repository;
using Pastebin.Infrastructure.Jwt;
using Pastebin.Persistence.EFCoreMSSQL;
using Pastebin.Persistence.EFCoreMSSQL.Repositories;

namespace Pastebin.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var services = builder.Services;
            var configuration = builder.Configuration;

            services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));
            services.AddApiAuthentication(configuration);

            services.AddAuthorization();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGenExtension();

            services.AddDbContext<PastebinDbContext>();

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<UserService>();

            services.AddScoped<IJwtProvider, JwtProvider>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.AddMappedEndpoints();

            app.UseAuthentication();
            app.UseAuthorization();

            app.Run();
        }
    }
}
