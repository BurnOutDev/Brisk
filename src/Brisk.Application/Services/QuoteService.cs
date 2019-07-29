using AutoMapper;
using Brisk.Domain.Entities;
using Brisk.Domain.Models;
using Brisk.Persistence;
using Microsoft.EntityFrameworkCore;
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

        public IEnumerable<QuoteOutput> GetAll(int skip, int take, string filter)
        {
            var skipped = _context.Quotes.Include(p => p.Author);

            var quotes = _mapper.Map<IEnumerable<QuoteOutput>>(skipped);

            if (!string.IsNullOrWhiteSpace(filter))
            {
                filter = filter.ToLower();
                quotes = quotes.Where(quote => quote.Author.ToLower().Contains(filter) || quote.Content.ToLower().Contains(filter));
            }

            quotes = quotes.Skip(skip).Take(take);

            return quotes;
        }

        public QuoteOutput GetById(int id)
        {
            var quoteFound = _context.Quotes.Where(qoute => qoute.Id == id).Include(property => property.Author).FirstOrDefault();
            var quote = _mapper.Map<QuoteOutput>(quoteFound);
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

        public ICollection<AuthorOutput> GetAuthors()
        {
            return _context.Authors.Select(author => new AuthorOutput
            {
                Author = author.Name,
                AuthorId = author.Id
            }).ToHashSet();
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
    }
}
