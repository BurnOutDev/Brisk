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

        public GameService(BriskDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GameModel StartNewGame(int userId)
        {
            var player = PlayerByUserId(userId);

            var answeredQuestions = AnsweredQuestionsByPlayer(player);

            var questions = RandomQuotesExcept(answeredQuestions);

            var game = new Game
            {
                GameMode = player.GameMode,
                Player = player,
                Questions = questions,
                QuestionCount = player.QuestionCount
            };

            _context.Add(game);
            _context.SaveChanges();

            var gameModel = _mapper.Map<GameModel>(game);

            return gameModel;
        }

        private ICollection<Question> RandomQuotesExcept(ICollection<Question> except)
        {
            var quotes = _context.Question
                .Except(except)
                .OrderBy(element => Guid.NewGuid())
                .Take(10)
                .ToHashSet();

            return quotes;
        }
        private ICollection<Question> AnsweredQuestionsByPlayer(Player player)
        {
            return player.PlayedGames
                .SelectMany(game => game.Questions)
                .ToHashSet();
        }
        private Player PlayerByUserId(int userId)
        {
            return _context.Players
                .FirstOrDefault(p => p.User.Id == userId);
        }
    }
}
