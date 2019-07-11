using System;
using System.Collections.Generic;
using System.Text;
using Brisk.Domain.Entities;

namespace Brisk.Domain.Models
{
    public class QuoteOutput
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public int AuthorId { get; set; }
    }
}
