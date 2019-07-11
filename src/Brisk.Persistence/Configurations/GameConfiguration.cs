using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Brisk.Domain.Entities;
using Brisk.Domain.Enums;
using System;

namespace Brisk.Persistence.Configurations
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            SharedConfiguration.Configure(builder);
            
            builder.Property(p => p.GameMode)
                .HasConversion(x =>
                    x.ToString(),
                    x => (AnswerMode)Enum.Parse(typeof(AnswerMode), x))
                .HasMaxLength(32);

            
        }
    }
}