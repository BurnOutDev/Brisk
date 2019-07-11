﻿using Brisk.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brisk.Domain.Models
{
    public class GameModel
    {
        public int GameId { get; set; }

        public AnswerMode GameMode { get; set; }
        public int QuestionCount { get; set; }

        public DateTime FinishedDate { get; set; }

        public ICollection<Answer> Answers { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
