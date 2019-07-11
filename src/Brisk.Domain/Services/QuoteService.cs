using AutoMapper;
using Brisk.Domain.Database;
using Brisk.Domain.DTOs.Input;
using Brisk.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Brisk.Domain
{
    public class QuoteService
    {
        private QuizContext _context;
        private IMapper _mapper;

        public QuoteService(QuizContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //public bool CheckAnswer(int quoteId, int authorId)
        //{
        //    var quote = _context.Quotes.Find(quoteId);
        //    return quote.Author.Id == authorId;
        //}

        public IEnumerable<QuoteOutput> GetAll()
        {
            var quotes = _mapper.Map<IEnumerable<QuoteOutput>>(_context.Quotes);
            return quotes;
        }

        public QuoteOutput GetById(int id)
        {
            var quote = _mapper.Map<QuoteOutput>(_context.Quotes.Find(id));
            return quote;
        }

        public QuoteOutput Create(string content, int authorId)
        {
            var author = _context.Authors.Find(authorId);
            var quote = new Quote
            {
                Author = author,
                Content = content
            };
       
            var entry = _context.Quotes.Add(quote);
            var output = _mapper.Map<QuoteOutput>(quote);

            return output;
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
