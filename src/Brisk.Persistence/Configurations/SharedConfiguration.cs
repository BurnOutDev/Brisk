using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Brisk.Domain.Entities;
using Brisk.Domain.Enums;
using System;
using Brisk.Domain.Entities.Shared;

namespace Brisk.Persistence.Configurations
{
    public static class SharedConfiguration
    {
        public static void Configure<T>(EntityTypeBuilder<T> builder) where T : BaseEntity
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.IsDeleted).HasDefaultValue(false);

            builder.Property(p => p.CreateDate).HasDefaultValue(DateTime.Now);
        }
    }
}