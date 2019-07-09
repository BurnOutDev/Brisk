using FlatRockTech.FamousQuoteQuiz.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FlatRockTech.FamousQuoteQuiz.Domain.Database
{
    public class QuizContext : DbContext
    {
        public QuizContext()
        {
        }

        public QuizContext(DbContextOptions<QuizContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Seed(builder);

            base.OnModelCreating(builder);
        }

        private void Seed(ModelBuilder builder)
        {
            builder.Entity<User>().HasData(new User { Id = 12, Username = "burnoutdevs" });
        }

        public DbSet<User> Users { get; set; }
    }
}