using Brisk.Domain.Entities.Shared;
using Brisk.Domain.Enums;

namespace Brisk.Domain.Entities
{
    public class Answer : BaseEntity
    {
        public virtual Question Question { get; set; }
        public virtual Choice Choice { get; set; }
        public virtual Game Game { get; set; }

        public BinaryChoice BinaryAnswer { get; set; }
        public AnswerMode AnswerMode { get; set; }
    }
}