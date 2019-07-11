using System.Collections.Generic;
using Brisk.Domain.Entities;

namespace Brisk.Application
{
    public interface IGameService
    {
        Player PlayerByUserId(int userId);
        ICollection<Answer> RandomQuotesExcept(ICollection<Quote> except);
        Game StartNewGame(int userId);
    }
}