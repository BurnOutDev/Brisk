using Brisk.Domain.Entities.Shared;
using System.Collections.Generic;

namespace Brisk.Domain.Entities
{
    public class Quote : BaseEntity
    {
        public string Content { get; set; }
        public virtual Author Author { get; set; }
    }
}
