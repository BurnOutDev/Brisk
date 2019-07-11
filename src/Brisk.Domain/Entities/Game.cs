using Brisk.Domain.Enums;
using System.Collections;
using System.Collections.Generic;

namespace Brisk.Domain.Entities
{
    public class Game : BaseEntity
    {
        public Player Player { get; set; }
        public ICollection<AnsweredQuote> AnsweredQuotes { get; set; }
        public GameMode GameMode { get; set; }
    }
}