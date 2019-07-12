using AutoMapper;
using Brisk.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Brisk.Domain.Models;
using System.Linq;

namespace Brisk.Domain.AutomapperProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AuthenticationInput, User>();
            CreateMap<UserInput, User>();
            CreateMap<UserInput, User>();
            CreateMap<User, AuthenticationOutput>();
            CreateMap<User, UserOutput>();

            CreateMap<Quote, QuoteOutput>()
                .ForMember(
                    member => member.Author, 
                    options => options.MapFrom(
                        source => source.Author.Name))
                .ForMember(member => member.AuthorId,
                    options => options.MapFrom(
                        source => source.Author.Id));

            CreateMap<Game, GameModel>()
           .ForMember(
               member => member.GameId,
               options => options.MapFrom(
                   source => source.Id))
           .ForMember(member => member.Questions,
               options => options.MapFrom(
                   source => source.Questions.Select(question => new QuestionModel
                   {
                       Quote = question.Quote.Content,
                       QuestionId = question.Id,
                       Choices = question.Choices.Select(choice => new ChoiceModel
                       {
                           AuthorName = choice.Author.Name,
                           ChoiceId = choice.Id
                       }).ToHashSet()
                   })));
        }
    }
}
