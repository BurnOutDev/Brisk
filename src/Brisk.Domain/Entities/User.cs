﻿using Brisk.Domain.Entities.Shared;
using Brisk.Domain.Enums;

namespace Brisk.Domain.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public Role Role { get; set; }
        public bool Disabled { get; set; }
    }
}
