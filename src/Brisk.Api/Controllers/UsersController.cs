﻿
using AutoMapper;
using Brisk.Domain;
using Brisk.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Brisk.Application;
using Brisk.Domain.Models;

namespace Brisk.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public UsersController(
            IUserService userService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]AuthenticationInput input)
        {
            var user = _userService.Authenticate(input.Username, input.Password);

            if (user == null)
                return Unauthorized(new { message = "Username or password is incorrect" });

            user = TokenOutput(user);

            return Ok(user);
        }

        private AuthenticationOutput TokenOutput(AuthenticationOutput user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            user.Token = tokenString;

            return user;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody]UserInput input)
        {
            try
            {
                var user = _userService.Create(input.FirstName, input.LastName, input.Username, input.Password);

                user = TokenOutput(user);

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAll(int skip, int take, string filter)
        {
            var outputs = _userService.GetAll(skip, take, filter);
            return Ok(outputs);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetById(id);
            var userDto = _mapper.Map<UserOutput>(user);
            return Ok(userDto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]UserInput input)
        {
            try
            {
                _userService.Update(id, input.FirstName, input.LastName, input.Username, input.Disabled, input.Password);
                return Ok(new UserOutput
                {
                    Id = id,
                    FirstName = input.FirstName,
                    LastName = input.LastName,
                    Role = "Admin",
                    Username = input.Username,
                    Disabled = input.Disabled
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            return Ok();
        }
    }
}
