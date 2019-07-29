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

        public virtual Player Player { get; set; }

        public virtual AnswerMode AnswerMode { get; set; }
        public virtual int QuestionCount { get; set; }

        public virtual DateTime FinishedDate { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}