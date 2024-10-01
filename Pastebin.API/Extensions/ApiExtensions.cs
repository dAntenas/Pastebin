using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Pastebin.API.Endpoints;
using Pastebin.Infrastructure.Jwt;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Pastebin.API.Extensions
{
    internal static class ApiExtensions
    {
        public static void AddMappedEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            endpointRouteBuilder.MapUserEndpoints();
        }

        public static void AddApiAuthentication(
            this IServiceCollection services,
            IConfiguration configuration
            )
        {
            var jwtOptions = configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.TokenValidationParameters = new()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions!.SecretKey))
                    };
                })
                ;

            services.AddAuthorization();
        }

        public static void AddSwaggerGenExtension(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition(
                    JwtBearerDefaults.AuthenticationScheme,
                    new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Header,
                        Description = "Enter a Bearer token",
                        Name = "Authentication",
                        Type = SecuritySchemeType.Http,
                        BearerFormat = JwtConstants.HeaderType,
                        Scheme = JwtBearerDefaults.AuthenticationScheme
                    }
                    );

                options.AddSecurityRequirement(
                    new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = JwtBearerDefaults.AuthenticationScheme
                                }
                            },
                            Array.Empty<string>()
                        }
                    }
                    );
            }
            );
        }

        public static void AddHttpClientExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient();
            //services.AddHttpClient(DropboxConstants.Dropbox, configure =>
            //{
            //    configure.BaseAddress = new Uri(DropboxConstants.Dropbox);
            //});
        }
    }
}
