using AutoMapper;
using Brisk.Domain.Entities;
using Brisk.Domain.Models;
using Brisk.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Brisk.Application
{
    public class QuoteService : IQuoteService
    {
        private BriskDbContext _context;
        private IMapper _mapper;

        public QuoteService(BriskDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

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

        public QuoteOutput Create(string content, string authorName, int? authorId)
        {
            var author = FindOrCreateAuthor(authorId, authorName);

            var quote = new Quote
            {
                Author = author,
                Content = content
            };

            var entry = _context.Quotes.Add(quote);
            _context.SaveChanges();

            var output = _mapper.Map<QuoteOutput>(quote);

            return output;
        }

        public void Update(int id, string content, string authorName, int? authorId)
        {
            var quote = _context.Find<Quote>(id);
            var author = FindOrCreateAuthor(authorId, authorName);

            quote.Content = content;
            quote.Author = author;

            _context.Quotes.Update(quote);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var quote = _context.Quotes.Find(id);
            if (quote != null)
            {
                _context.Quotes.Remove(quote);
                _context.SaveChanges();
            }
        }

        private Author FindOrCreateAuthor(int? authorId, string authorName)
        {
            var author = _context.Authors.Find(authorId);

            if (author == null)
            {
                author = new Author
                {
                    Name = authorName
                };
            }

            return author;
        }

        private QuestionModel GenerateQuestion(Quote quote)
        {
            var question = new Question();
            question.Quote = quote;
            question.Choices.Add()
        }
    }
}
