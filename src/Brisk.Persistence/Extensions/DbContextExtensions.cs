using Brisk.Domain.Entities;
using Brisk.Domain.Entities.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;

namespace Brisk.Persistence.Extensions
{
    public static class DbContextExtensions
    {
        public static IQueryable<T> ById<T>(this IQueryable<T> source, int id) where T : IBaseEntity
        {
            return source.Where(entity => entity.Id == id);
        }

        public static IQueryable<T> Random<T>(this IQueryable<T> source, int count) where T : IBaseEntity
        {
            var seedText = Guid.NewGuid().ToString();

            seedText = new string(seedText.Where(c => char.IsDigit(c))
                .Take(5).ToArray());

            var seed = int.Parse(seedText);

            var random = new Random(seed);

            var skip = random.Next(source.Count());

            return source.Skip(skip).Take(count);
        }

        public static IQueryable<T> LocalOrDatabase<T>(this DbContext context, Expression<Func<T, bool>> expression)
            where T : class
        {
            var localResults = context.Set<T>().Local.Where(expression.Compile());

            var enumerable = localResults.ToList();
            if (enumerable.Any()) return enumerable.AsQueryable();

            var databaseResults = context.Set<T>().Where(expression);

            return databaseResults;
        }

        public static IQueryable<T> ChoiceWithQuestion<T>(this DbContext context, Expression<Func<T, bool>> expression) where T : class
        {
            var localResults = context.Set<T>().Local.Where(expression.Compile());

            var enumerable = localResults.ToList();
            if (enumerable.Any()) return enumerable.AsQueryable();

            var databaseResults = context.Set<T>().Where(expression);

            return databaseResults;
        }

    }
}
