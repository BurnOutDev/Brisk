using Brisk.Domain.Entities;
using Brisk.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brisk.Domain.Models.Output
{
    class StartNewGameOutput
    {
        public User User { get; set; }

        public AnswerMode AnswerMode { get; set; }
        public int QuestionCount { get; set; }

        public DateTime FinishedDate { get; set; }

        public ICollection<QuestionModel> Questions { get; set; }
    }
}
