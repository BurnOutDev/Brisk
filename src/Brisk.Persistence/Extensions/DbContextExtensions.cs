using Brisk.Domain.Entities.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Brisk.Persistence.Extensions
{
    public static class DbContextExtensions
    {
        public static IQueryable<T> ById<T>(this IQueryable<T> source, int id) where T : IBaseEntity
        {
            return source.Where(entity => entity.Id == id);
        }

        public static IQueryable<T> GetActiveEntities<T>(this IQueryable<T> source) where T : IBaseEntity
        {
            return source.Where(entity => !entity.IsDeleted);
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
    }
}
