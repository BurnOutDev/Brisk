using System.Collections;
using System.Collections.Generic;

namespace FlatRockTech.FamousQuoteQuiz.Domain.Entities
{
    public class AnsweredQuote : BaseEntity
    {
        public Quote Quote { get; set; }
        public Author Answer { get; set; }
        public bool IsRight { get
            {
                return Quote.Author.Id == Answer.Id;
            }
        }
    }
}