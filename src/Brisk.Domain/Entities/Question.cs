using Brisk.Domain.Entities.Shared;
using System.Collections.Generic;

namespace Brisk.Domain.Entities
{
    public class Question : BaseEntity
    {
        public Quote Quote { get; set; }
        public ICollection<Choice> Choices { get; set; }
    }
}
