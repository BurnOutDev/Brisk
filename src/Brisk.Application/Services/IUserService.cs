using Brisk.Domain.Entities;
using Brisk.Domain.Models;
using System.Collections.Generic;

namespace Brisk.Application
{
    public interface IUserService
    {
        AuthenticationOutput Authenticate(string username, string password);
        IEnumerable<UserOutput> GetAll(int skip, int take, string filter);
        UserOutput GetById(int id);
        AuthenticationOutput Create(string firstName, string lastName, string username, string password);
        void Update(int id, string firstName, string lastName, string username, bool disabled, string password = null);
        void Delete(int id);
        int UserId { get; set; }
    }
}
