using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Brisk.Domain.Entities;
using Brisk.Domain.Enums;
using System;

namespace Brisk.Persistence.Configurations
{
    public class QuoteConfiguration : IEntityTypeConfiguration<Quote>
    {
        public void Configure(EntityTypeBuilder<Quote> builder)
        {
            SharedConfiguration.Configure(builder);

            builder.Property(p => p.Content).HasMaxLength(512);

            builder.HasOne(p => p.Author).WithMany(x => x.Quotes);
        }
    }
}