using Brisk.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brisk.Domain.Models
{
    public class AnswerModel
    {
        public int GameId { get; set; }
        public int ChoiceId { get; set; }
        public BinaryChoice BinaryChoice { get; set; }
    }
}
