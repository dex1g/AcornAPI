using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Acorn.BL.Models;
using Acorn.BL.Services;
using Microsoft.AspNetCore.Mvc;

namespace AcornAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BotsController : ControllerBase
    {
        private readonly IBotService _botService;

        private readonly IMapper _mapper;

        public BotsController(IBotService botService, IMapper mapper)
        {
            _botService = botService;
            _mapper = mapper;
        }

        // PUT: api/Bot/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBot(uint id, [FromBody]Bot bot)
        {
            bot.BotId = id;
            try
            {
                await _botService.UpdateBotAsync(_mapper.Map<Bot>(bot));
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Bots
        [HttpPost]
        public async Task<ActionResult> CreateBot([FromBody]Bot bot)
        {
            try
            {
                Config botConfig = new Config { Bot = bot, BotId = bot.BotId };
                bot.Config = botConfig;
                await _botService.CreateNewBotAsync(_mapper.Map<Bot>(bot));
                //await _configService.CreateNewConfigAsync(botConfig);
                //return CreatedAtAction(nameof(GetBotById), new { BotId = bot.BotId }, bot);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBot(uint id)
        {
            try
            {
                await _botService.DeleteBotAsync(id);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Bots
        [HttpGet]
        public async Task<ActionResult> GetAllBots()
        {
            var bots = await _botService.GetAllBotsAsync();

            var botsToReturn = _mapper.Map<IEnumerable<Bot>>(bots);

            return Ok(botsToReturn);
        }

        // GET: api/Bots/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bot>> GetBotById(uint id)
        {
            try
            {
                var bot = await _botService.GetBotByIdAsync(id);

                return Ok(_mapper.Map<Bot>(bot));
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
