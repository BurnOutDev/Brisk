using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Brisk.Domain.Entities;
using Brisk.Domain.Enums;
using System;
using Brisk.Domain.Entities.Shared;

namespace Brisk.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            SharedConfiguration.Configure(builder);

            builder.Property(p => p.FirstName).HasMaxLength(64);
            builder.Property(p => p.LastName).HasMaxLength(128);

            builder.Property(p => p.Role)
                .HasConversion(x =>
                    x.ToString(),
                    x => (Role)Enum.Parse(typeof(Role), x))
                .HasMaxLength(32);

            Seed(builder);
        }

        public void Seed<T>(EntityTypeBuilder<T> builder) where T : BaseEntity
        {
        }
    }
}