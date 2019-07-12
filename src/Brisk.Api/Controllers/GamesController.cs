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
using Brisk.Domain.Enums;
using Brisk.Domain.Models;

namespace Brisk.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {
        private IUserService _userService;
        private IGameService _gameService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public GamesController(
            IUserService userService,
            IGameService gameService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
            _gameService = gameService;
        }

        [HttpGet]
        [Route("start-new-game")]
        public IActionResult StartNewGame()
        {
            var output = _gameService.StartNewGame(_userService.UserId);

            return Ok(output);
        }

        [HttpPost]
        [Route("answer")]
        public IActionResult StartNewGame(AnswerModel answer)
        {
            var output = _gameService.Answer(answer, _userService.UserId);

            return Ok(output);
        }
    }
}
