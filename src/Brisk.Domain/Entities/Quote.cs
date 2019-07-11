using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Brisk.Domain.Entities
{
    public class Quote : BaseEntity
    {
        public string Content { get; set; }
        public Author Author { get; set; }
    }
}
