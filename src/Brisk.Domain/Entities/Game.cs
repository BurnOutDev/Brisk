using Brisk.Domain.Entities.Shared;
using Brisk.Domain.Enums;
using System.Collections.Generic;

namespace Brisk.Domain.Entities
{
    public class Game : BaseEntity
    {
        public Game()
        {
            //AnsweredQuotes = new HashSet<Answer>();
        }

        public Player Player { get; set; }
        public AnswerMode GameMode { get; set; }

        public ICollection<Answer> Answers { get; set; }
        public ICollection<Question> Questions { get; set; }

        public bool IsFinished { get; set; }
    }
}