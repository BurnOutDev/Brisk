using FlatRockTech.FamousQuoteQuiz.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlatRockTech.FamousQuoteQuiz.Domain.Entities
{
    public class Player : BaseEntity
    {
        public ICollection<Game> PlayedGames { get; set; }
        public GameMode GameMode { get; set; }
    }
}
