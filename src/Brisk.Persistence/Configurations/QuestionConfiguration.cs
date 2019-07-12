using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Brisk.Domain.Entities;
using Brisk.Domain.Enums;
using System;

namespace Brisk.Persistence.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            SharedConfiguration.Configure(builder);
            builder.Property(p => p.AnswerMode)
                .HasConversion(x =>
                    x.ToString(),
                    x => (AnswerMode)Enum.Parse(typeof(AnswerMode), x))
                .HasMaxLength(32);
        }
    }
}