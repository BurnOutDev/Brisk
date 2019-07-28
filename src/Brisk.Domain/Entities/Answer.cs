﻿using Brisk.Domain.Entities.Shared;
using Brisk.Domain.Enums;

namespace Brisk.Domain.Entities
{
    public class Answer : BaseEntity
    {
        public Question Question { get; set; }
        public Choice Choice { get; set; }
        public Game Game { get; set; }

        public BinaryChoice BinaryAnswer { get; set; }
        public AnswerMode AnswerMode { get; set; }
    }
}