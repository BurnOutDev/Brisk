using Brisk.Domain.Entities.Shared;
using Brisk.Domain.Enums;
using System.Collections.Generic;

namespace Brisk.Domain.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
            PlayedGames = new HashSet<Game>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public Role Role { get; set; }
        public bool Disabled { get; set; }

        public virtual AnswerMode AnswerMode { get; set; }
        public virtual int QuestionCount { get; set; }

        public virtual ICollection<Game> PlayedGames { get; set; }
    }
}
