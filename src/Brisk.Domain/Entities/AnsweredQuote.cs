using Brisk.Domain.Entities.Shared;

namespace Brisk.Domain.Entities
{
    public class AnsweredQuote : BaseEntity
    {
        public Quote Quote { get; set; }
        public Author Answer { get; set; }
        public bool IsRight
        {
            get
            {
                return Quote.Author.Id == Answer.Id;
            }
        }
    }
}