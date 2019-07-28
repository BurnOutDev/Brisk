using System;
using System.Collections.Generic;
using System.Text;

namespace Brisk.Domain.Models
{
    public class AuthenticationOutput
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}
