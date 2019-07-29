using Brisk.Domain.Entities.Shared;
using Brisk.Domain.Enums;
using System.Collections.Generic;

namespace Brisk.Domain.Entities
{
    public class Player : BaseEntity
    {
        public Player()
        {
            PlayedGames = new HashSet<Game>();
        }

        public virtual User User { get; set; }
        public virtual AnswerMode AnswerMode { get; set; }
        public virtual int QuestionCount { get; set; }
 
        public virtual ICollection<Game> PlayedGames { get; set; }
    }
}
