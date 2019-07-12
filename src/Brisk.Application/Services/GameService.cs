﻿using AutoMapper;
using Brisk.Domain.Entities;
using Brisk.Domain.Models;
using Brisk.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using Brisk.Persistence.Extensions;
using Brisk.Domain.Enums;
using Microsoft.EntityFrameworkCore;

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

            var game = new Game
            {
                AnswerMode = player.AnswerMode,
                Player = player,
                QuestionCount = player.QuestionCount
            };

            var answeredQuestions = AnsweredQuestionsByPlayer(player).Select(question => question.Quote).ToHashSet();

            var quotes = RandomQuotesExcept(answeredQuestions, game.QuestionCount);

            game.Questions = GenerateQuestions(quotes, game.AnswerMode);

            _context.Add(game);
            _context.SaveChanges();

            var questionModels = new HashSet<QuestionModel>();

            var gameModel = _mapper.Map<GameModel>(game);

            return gameModel;
        }
        public AnswerResponseModel Answer(AnswerModel answer, int userId)
        {
            var response = new AnswerResponseModel();

            var game = _context.Games.ById(answer.GameId).FirstOrDefault();

            var choice = _context.Choices
                .Include(fk => fk.Question)
                .Include(fk => fk.Author)
                .Include(fk => fk.Question.Quote)
                .ById(answer.ChoiceId)
                .FirstOrDefault();
            
            _context.Add(new Answer
            {
                AnswerMode = game.AnswerMode,
                BinaryAnswer = answer.BinaryChoice,
                Choice = choice,
                Game = game,
                Question = choice.Question
            });

            choice.Question.Status = QuestionStatus.Answered;

            _context.SaveChanges();

            response.IsCorrect = choice.Question.Quote.Author == choice.Author;

            return response;
        }

        private ICollection<Quote> RandomQuotesExcept(ICollection<Quote> except, int count)
        {
            var quotes = _context.Quotes
                .Include(fk => fk.Author)
                //.Except(except)
                .Random(count)
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
        private ICollection<Question> GenerateQuestions(ICollection<Quote> quotes, AnswerMode AnswerMode)
        {
            var questions = new HashSet<Question>();

            foreach (var quote in quotes)
            {
                var question = new Question();

                question.Quote = quote;
                question.AnswerMode = AnswerMode;

                var authors = _context.Authors.Random(2).ToList();
                authors.Add(quote.Author);

                authors.ForEach(author => question.Choices
                .Add(new Choice
                {
                    Author = author
                }));

                question.Choices.ToList().AddRange(
                    authors.Select(author => new Choice
                    {
                        Author = author
                    }));

                if (AnswerMode == AnswerMode.Binary)
                {
                    var random = question.Choices.AsQueryable().Random(1).FirstOrDefault();
                    question.Choices.Clear();
                    question.Choices.Add(random);
                }

                questions.Add(question);
            }

            return questions;
        }
    }
}
