using System.Collections.Generic;
using Brisk.Domain.Entities;

namespace Brisk.Application
{
    public interface IGameService
    {
        Player GetPlayerByUserId(int userId);
        ICollection<AnsweredQuote> GetRandomQuotes();
        Game StartNewGame(int userId);
    }
}