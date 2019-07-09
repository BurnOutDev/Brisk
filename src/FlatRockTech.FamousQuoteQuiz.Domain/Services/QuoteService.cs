using FlatRockTech.FamousQuoteQuiz.Domain.Database;
using FlatRockTech.FamousQuoteQuiz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FlatRockTech.FamousQuoteQuiz.Domain
{
    public class QuoteService
    {
        private QuizContext _context;

        public QuoteService(QuizContext context)
        {
            _context = context;
        }

        public bool CheckAnswer(int quoteId, int authorId)
        {
            var quote = _context.Quotes.Find(quoteId);
            return quote.Author.Id == authorId;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(int id)
        {
            return _context.Users.Find(id);
        }

        public User Create(User user, string password)
        {
            return user;
        }

        public void Update(User userParam, string password = null)
        {
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}
