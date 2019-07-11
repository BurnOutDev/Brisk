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

            var answeredQuestions = AnsweredQuestionsByPlayer(player);

            var questions = RandomQuotesExcept(answeredQuestions);

            var game = new Game
            {
                GameMode = player.GameMode,
                Player = player,
                Questions = questions
            };

            //_context.SaveChanges();

            //return game;
            return null;
        }

        public ICollection<Question> RandomQuotesExcept(ICollection<Question> except)
        {
            var quotes = _context.Question
                .Except(except)
                .OrderBy(element => Guid.NewGuid())
                .Take(10)
                .ToHashSet();

            return quotes;
        }

        public ICollection<Question> AnsweredQuestionsByPlayer(Player player)
        {
            return player.PlayedGames
                .SelectMany(game => game.Questions)
                .ToHashSet();
        }

        public Player PlayerByUserId(int userId)
        {
            return _context.Players
                .FirstOrDefault(p => p.User.Id == userId);
        }
    }
}
