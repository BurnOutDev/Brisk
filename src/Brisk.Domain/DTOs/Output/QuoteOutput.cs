using System;
using System.Collections.Generic;
using System.Text;

namespace Brisk.Domain.DTOs.Input
{
    public class QuoteOutput
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public int AuthorId { get; set; }
    }
}
