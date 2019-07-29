using Brisk.Domain.Entities.Shared;
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

        public virtual Quote Quote { get; set; }
        public virtual Game Game { get; set; }

        public virtual AnswerMode AnswerMode { get; set; }
        public virtual QuestionStatus Status { get; set; }

        public virtual ICollection<Choice> Choices { get; set; }
    }
}
