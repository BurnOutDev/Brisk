using AutoMapper;
using Brisk.Domain.Entities;
using Brisk.Domain.Models;
using Brisk.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Brisk.Application
{
    public class UserService : IUserService
    {
        private BriskDbContext _context;
        private IMapper _mapper;

        public int UserId { get; set; }

        public UserService(BriskDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public AuthenticationOutput Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = _context.Users.SingleOrDefault(x => x.Username == username);

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            var token = _mapper.Map<AuthenticationOutput>(user);

            return token;
        }

        public IEnumerable<UserOutput> GetAll(int skip, int take, string filter)
        {
            var users = _mapper.Map<IEnumerable<UserOutput>>(_context.Users);

            if (!string.IsNullOrWhiteSpace(filter))
            {
                filter = filter.ToLower();
                users = users.Where(user => user.Username.ToLower().Contains(filter) 
                                            || user.FirstName.ToLower().Contains(filter)
                                            || user.LastName.ToLower().Contains(filter));
            }

            users = users.Skip(skip).Take(take);

            return users;
        }

        public UserOutput GetById(int id)
        {
            var user = _context.Users.Find(id);
            return _mapper.Map<UserOutput>(user);
        }

        public UserOutput Create(string firstName, string lastName, string username, string password)
        {
            var user = new User();
            user.FirstName = firstName;
            user.LastName = lastName;
            user.Username = username;

            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("Password is required");

            if (_context.Users.Any(x => x.Username == username))
                throw new Exception("Username \"" + username + "\" is already taken");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.Users.Add(user);
            _context.SaveChanges();

            var userOutput = _mapper.Map<UserOutput>(user);

            return userOutput;
        }

        public void Update(int id, string firstName, string lastName, string username, bool disabled, string password = null)
        {
            var user = _context.Users.Find(id);

            if (user == null)
                throw new Exception("User not found");

            if (username != user.Username)
            {
                // check if the new username is already taken
                if (_context.Users.Any(x => x.Username == username))
                    throw new Exception("Username " + username + " is already taken");
            }

            user.FirstName = firstName;
            user.LastName = lastName;
            user.Username = username;
            user.Disabled = disabled;

            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        #region Helper Methods
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }

        #endregion
    }
}