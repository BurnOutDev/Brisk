using AutoMapper;
using FlatRockTech.FamousQuoteQuiz.Domain.Entities;
using FlatRockTech.FamousQuoteQuiz.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlatRockTech.FamousQuoteQuiz.Domain.AutomapperProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AuthenticationInput, User>();
            CreateMap<UserInput, User>();
            CreateMap<UpdateUserInput, User>();
            CreateMap<UserInput, User>();
            CreateMap<User, AuthenticationOutput>();
            CreateMap<User, UserOutput>();
        }
    }
}
