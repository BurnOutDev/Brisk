using Brisk.Domain.Entities.Shared;
using Brisk.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Brisk.Domain.Entities
{
    public class Game : BaseEntity
    {
        public Game()
        {
            Answers = new HashSet<Answer>();
            Questions = new HashSet<Question>();
        }

        public User User { get; set; }

        public virtual AnswerMode AnswerMode { get; set; }
        public int QuestionCount { get; set; }

        public DateTime? FinishedDate { get; set; }
        public bool IsFinished { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}