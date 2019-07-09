using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FlatRockTech.FamousQuoteQuiz.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
