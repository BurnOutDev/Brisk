using Brisk.Domain.Entities;
using Brisk.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brisk.Domain.Models.Output
{
    class StartNewGameOutput
    {
        public Player Player { get; set; }

        public AnswerMode GameMode { get; set; }
        public int QuestionCount { get; set; }

        public DateTime FinishedDate { get; set; }

        public ICollection<QuestionModel> Questions { get; set; }
    }
}
