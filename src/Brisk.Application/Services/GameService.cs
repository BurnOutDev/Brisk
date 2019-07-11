using AutoMapper;
using Brisk.Domain.Entities;
using Brisk.Domain.Models;
using Brisk.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Brisk.Application
{
    public class GameService : IGameService
    {
        private BriskDbContext _context;
        private IMapper _mapper;
        private IUserService _userService;

        public GameService(BriskDbContext context, IUserService userService, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
        }

        public Game StartNewGame(int userId)
        {
            var player = PlayerByUserId(userId);

            var exceptQuotes = AnsweredQuotesByPlayer(player);

            var quotes = RandomQuotes(exceptQuotes);

            var game = new Game
            {
                GameMode = player.GameMode,
                Player = player,
                AnsweredQuotes = quotes
            };

            _context.SaveChanges();

            return game;
        }

        public ICollection<Answer> RandomQuotes(ICollection<Quote> except)
        {
            var quotes = _context.Quotes
                .OrderBy(element => Guid.NewGuid())
                .Take(10)
                .Select(quote => new Answer
                {
                    Quote = quote
                }).ToHashSet();

            return quotes;
        }

        public ICollection<Quote> AnsweredQuotesByPlayer(Player player)
        {
            return player.PlayedGames.SelectMany(game => game.AnsweredQuotes.Select(quote => quote.Quote)).ToHashSet();
        }

        public Player PlayerByUserId(int userId)
        {
            return _context.Players.FirstOrDefault(p => p.User.Id == userId);
        }
    }
}
