﻿using Brisk.Domain.Models;
using System.Collections.Generic;

namespace Brisk.Application
{
    public interface IQuoteService
    {
        QuoteOutput Create(string content, string authorName, int? authorId);
        void Delete(int id);
        IEnumerable<QuoteOutput> GetAll(int skip, int take, string filter);
        QuoteOutput GetById(int id);
        void Update(int id, string content, string authorName, int? authorId);
        ICollection<AuthorOutput> GetAuthors();
    }
}