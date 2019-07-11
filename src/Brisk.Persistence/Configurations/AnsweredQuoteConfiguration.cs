using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Brisk.Domain.Entities;
using Brisk.Domain.Enums;
using System;

namespace Brisk.Persistence.Configurations
{
    public class AnsweredQuoteConfiguration : IEntityTypeConfiguration<AnsweredQuote>
    {
        public void Configure(EntityTypeBuilder<AnsweredQuote> builder)
        {
            SharedConfiguration.Configure(builder);
        }
    }
}