using System.Collections.Generic;

namespace FlatRockTech.FamousQuoteQuiz.Domain.Entities
{
    public class Author : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Quote> Quotes { get; set; }
    }
}