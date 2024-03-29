﻿using Brisk.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Brisk.Persistence
{
    public class BriskDbContext : DbContext
    {
        public BriskDbContext() { }

        public BriskDbContext(DbContextOptions<BriskDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(BriskDbContext).Assembly);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<Question> Question { get; set; }
    }
}