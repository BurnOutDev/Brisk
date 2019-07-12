﻿using Brisk.Domain.Entities.Shared;
using Brisk.Domain.Enums;
using System.Collections.Generic;

namespace Brisk.Domain.Entities
{
    public class Question : BaseEntity
    {
        public Question()
        {
            Choices = new HashSet<Choice>();
        }

        public Quote Quote { get; set; }
        public ICollection<Choice> Choices { get; set; }
        public BinaryChoice Answer { get; set; }
        public AnswerMode AnswerMode { get; set; }
    }
}
