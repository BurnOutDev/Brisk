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
            var player = GetPlayerByUserId(userId);

            var quotes = GetRandomQuotes();

            var game = new Game
            {
                GameMode = player.GameMode,
                Player = player,
                AnsweredQuotes = quotes
            };

            _context.SaveChanges();

            return game;
        }

        public ICollection<AnsweredQuote> GetRandomQuotes()
        {
            var quotes = _context.Quotes
                .OrderBy(element => Guid.NewGuid())
                .Take(10)
                .Select(quote => new AnsweredQuote
                {
                    Quote = quote
                }).ToHashSet();

            return quotes;
        }

        public Player GetPlayerByUserId(int userId)
        {
            return _context.Players.FirstOrDefault(p => p.User.Id == userId);
        }
    }
}
