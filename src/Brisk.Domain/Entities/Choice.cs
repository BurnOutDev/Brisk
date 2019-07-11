using Brisk.Domain.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brisk.Domain.Entities
{
    public class Choice : BaseEntity
    {
        public Author Author { get; set; }
        public Question Question { get; set; }
    }
}
