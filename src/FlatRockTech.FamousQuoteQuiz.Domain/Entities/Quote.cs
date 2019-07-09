using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FlatRockTech.FamousQuoteQuiz.Domain.Entities
{
    public class Quote : BaseEntity
    {
        public string Content { get; set; }
        public Author Author { get; set; }
    }
}
