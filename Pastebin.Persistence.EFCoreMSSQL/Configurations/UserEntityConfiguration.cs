using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pastebin.Core.Models;

namespace Pastebin.Persistence.EFCoreMSSQL.Configurations
{
    internal class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(p => p.Username)
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                ;

            builder.Property(p => p.PasswordHash)
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                ;

            builder.Property(p => p.Email)
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                ;
        }
    }
}
