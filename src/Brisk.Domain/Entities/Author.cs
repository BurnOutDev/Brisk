using System.Collections.Generic;

namespace Brisk.Domain.Entities
{
    public class Author : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Quote> Quotes { get; set; }
    }
}