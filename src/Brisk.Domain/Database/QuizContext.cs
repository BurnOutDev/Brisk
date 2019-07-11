using Brisk.Domain.Entities;
using Brisk.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Brisk.Domain.Database
{
    public class QuizContext : DbContext
    {
        public QuizContext() { }

        public QuizContext(DbContextOptions<QuizContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Game>(entity =>
            {
                entity.Property(e => e.GameMode)
                .HasConversion(x => x.ToString(),
                    x => (GameMode)Enum.Parse(typeof(GameMode), x));
            });

            builder.Entity<User>(entity =>
            {
                entity.Property(e => e.Role)
                .HasConversion(x => x.ToString(),
                    x => (Role)Enum.Parse(typeof(Role), x));
            });

            builder.Entity<Player>(entity =>
            {
                entity.Property(e => e.GameMode)
                .HasConversion(x => x.ToString(),
                    x => (GameMode)Enum.Parse(typeof(GameMode), x));
            });

            base.OnModelCreating(builder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<AnsweredQuote> AnsweredQuotes { get; set; }
    }
}