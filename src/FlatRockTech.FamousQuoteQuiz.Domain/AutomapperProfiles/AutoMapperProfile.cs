using AutoMapper;
using FlatRockTech.FamousQuoteQuiz.Domain.Entities;
using FlatRockTech.FamousQuoteQuiz.Domain.Models;
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
            CreateMap<RegistrationUserInput, User>();
            CreateMap<UpdateUserInput, User>();
            CreateMap<UserInput, User>();
        }
    }
}
