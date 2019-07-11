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
    [ApiController]
    [Route("api/[controller]")]
    public class QuotesController : ControllerBase
    {
        private IUserService _userService;
        private IQuoteService _quoteService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public QuotesController(
            IUserService userService,
            IQuoteService quoteService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _quoteService = quoteService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        public IActionResult Create([FromBody]QuoteInput quote)
        {
            var output = _quoteService.Create(quote.Content, quote.AuthorName, quote.AuthorId);
            return Ok(output);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var quotes = _quoteService.GetAll();
            var outputs = _mapper.Map<IList<QuoteOutput>>(quotes);
            return Ok(outputs);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var quote = _quoteService.GetById(id);
            var output = _mapper.Map<QuoteOutput>(quote);
            return Ok(output);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]QuoteInput input)
        {
            try
            {
                _quoteService.Update(id, input.Content, input.AuthorName, input.AuthorId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _quoteService.Delete(id);
            return Ok();
        }
    }
}
