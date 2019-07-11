using AutoMapper;
using Brisk.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Brisk.Domain.Models;

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
        }
    }
}
