using AutoMapper;
using Brisk.Domain.Entities;
using Brisk.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brisk.Domain.AutomapperProfiles
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
