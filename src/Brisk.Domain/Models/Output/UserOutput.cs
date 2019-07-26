using System;
using System.Collections.Generic;
using System.Text;

namespace Brisk.Domain.Models
{
    public class UserOutput
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public bool Disabled { get; set; }
    }
}
