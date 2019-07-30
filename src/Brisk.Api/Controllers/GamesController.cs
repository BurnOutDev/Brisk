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
        private IGameService _gameService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public GamesController(
            IGameService gameService,
            IMapper mapper)
        {
            _mapper = mapper;
            _gameService = gameService;
        }

        [HttpGet]
        [Route("start-new-game")]
        public IActionResult StartNewGame()
        {
            var output = _gameService.StartNewGame();

            return Ok(output);
        }

        [HttpPost]
        [Route("answer")]
        public IActionResult Answer(AnswerModel answer)
        {
            var output = _gameService.Answer(answer);

            return Ok(output);
        }

        [HttpGet]
        [Route("settings")]
        public IActionResult Settings()
        {
            var output = _gameService.PlayerSettings();

            return Ok(output);
        }

        [HttpPost]
        [Route("settings")]
        public IActionResult UpdateSettings(SettingsModel settings)
        {
            _gameService.UpdatePlayerSettings(settings);

            return Ok(settings);
        }
    }
}
