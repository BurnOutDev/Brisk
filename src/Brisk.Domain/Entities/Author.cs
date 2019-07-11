using Brisk.Domain.Entities.Shared;
using System.Collections.Generic;

namespace Brisk.Domain.Entities
{
    public class Author : BaseEntity
    {
        public Author()
        {
            Quotes = new HashSet<Quote>();
        }

        public string Name { get; set; }
        public ICollection<Quote> Quotes { get; set; }
    }
}