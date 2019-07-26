using System;
using System.Collections.Generic;
using System.Text;

namespace Brisk.Domain.Models
{
    public class UserInput
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Disabled { get; set; }
    }
}
