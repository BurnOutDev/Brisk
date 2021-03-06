﻿using Microsoft.EntityFrameworkCore;
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

            builder.Property(p => p.AnswerMode)
              .HasConversion(x =>
                  x.ToString(),
                  x => (AnswerMode)Enum.Parse(typeof(AnswerMode), x))
              .HasMaxLength(32);

            builder.Property(p => p.Disabled)
                .HasDefaultValue(false);

            builder.Property(p => p.AnswerMode)
                .HasDefaultValue(AnswerMode.Binary);

            builder.Property(p => p.QuestionCount)
                .HasDefaultValue(10);

            Seed(builder);
        }

        public void Seed<T>(EntityTypeBuilder<T> builder) where T : BaseEntity
        {
        }
    }
}