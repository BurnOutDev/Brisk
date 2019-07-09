using FlatRockTech.FamousQuoteQuiz.Domain.Enums;
using System.Collections;
using System.Collections.Generic;

namespace FlatRockTech.FamousQuoteQuiz.Domain.Entities
{
    public class Game : BaseEntity
    {
        public Player Player { get; set; }
        public ICollection<AnsweredQuote> AnsweredQuotes { get; set; }
        public GameMode GameMode { get; set; }
    }
}