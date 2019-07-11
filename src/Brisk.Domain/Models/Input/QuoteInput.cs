using System;
using System.Collections.Generic;
using System.Text;

namespace Brisk.Domain.Models
{
    public class QuoteInput
    {
        public int? Id { get; set; }
        public string Content { get; set; }
        public string AuthorName { get; set; }
        public int? AuthorId { get; set; }
    }
}
