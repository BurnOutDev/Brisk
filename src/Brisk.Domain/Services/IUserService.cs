﻿using Brisk.Domain.DTOs;
using Brisk.Domain.Entities;
using System.Collections.Generic;

namespace Brisk.Domain
{
    public interface IUserService
    {
        AuthenticationOutput Authenticate(string username, string password);
        IEnumerable<UserOutput> GetAll();
        UserOutput GetById(int id);
        UserOutput Create(string firstName, string lastName, string username, string password);
        void Update(int id, string firstName, string lastName, string username, string password = null);
        void Delete(int id);
    }
}
