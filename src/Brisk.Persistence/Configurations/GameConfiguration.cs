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
                    x => (GameMode)Enum.Parse(typeof(GameMode), x))
                .HasMaxLength(32);

            
        }
    }
}