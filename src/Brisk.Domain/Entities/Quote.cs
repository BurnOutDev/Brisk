﻿using Brisk.Domain.Entities.Shared;
using System.Collections.Generic;

namespace Brisk.Domain.Entities
{
    public class Quote : BaseEntity
    {
        public string Content { get; set; }
        public Author Author { get; set; }
    }
}
