using System;
using System.Collections.Generic;
using System.Text;

namespace FlatRockTech.FamousQuoteQuiz.Domain.Models
{
    public class AuthenticationResult
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
    }
}
