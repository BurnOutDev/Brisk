using Brisk.Domain.Entities.Shared;

namespace Brisk.Domain.Entities
{
    public class Answer : BaseEntity
    {
        public Question Question { get; set; }
        public Choice Choice { get; set; }
        public Game Game { get; set; }
    }
}