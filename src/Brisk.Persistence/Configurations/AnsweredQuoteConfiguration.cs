using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Brisk.Domain.Entities;
using Brisk.Domain.Enums;
using System;

namespace Brisk.Persistence.Configurations
{
    public class AnsweredQuoteConfiguration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            SharedConfiguration.Configure(builder);
        }
    }
}