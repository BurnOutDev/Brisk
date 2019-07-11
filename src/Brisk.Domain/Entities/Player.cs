using Brisk.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brisk.Domain.Entities
{
    public class Player : BaseEntity
    {
        public ICollection<Game> PlayedGames { get; set; }
        public GameMode GameMode { get; set; }
    }
}
