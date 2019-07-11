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

        public User User { get; set; }

        public ICollection<Game> PlayedGames { get; set; }
        public GameMode GameMode { get; set; }
    }
}
