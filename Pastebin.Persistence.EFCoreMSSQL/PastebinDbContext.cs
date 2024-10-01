using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Pastebin.Persistence.EFCoreMSSQL.Configurations;
using Pastebin.Persistence.EFCoreMSSQL.Entities;

namespace Pastebin.Persistence.EFCoreMSSQL
{
    public class PastebinDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public PastebinDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(_configuration.GetConnectionString(nameof(PastebinDbContext)))
                .UseLoggerFactory(CreateLoggerFactory())
                .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: Assembly apply
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        internal DbSet<UserEntity> Users { get; set; }

        //TODO: Remove
        public static ILoggerFactory CreateLoggerFactory() =>
            LoggerFactory.Create(builder => { builder.AddConsole(); });
    }
}
