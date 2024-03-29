﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Brisk.Domain.Models
{
    public class QuestionModel
    {
        public QuestionModel()
        {
            Choices = new HashSet<ChoiceModel>();
        }

        public int QuestionId { get; set; }
        public string Quote { get; set; }
        public ICollection<ChoiceModel> Choices { get; set; }
    }
}
