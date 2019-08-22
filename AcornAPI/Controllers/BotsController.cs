using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Acorn.BL.Models;
using Acorn.BL.Services;
using AcornAPI.Dtos;
using AcornAPI.SignalR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace AcornAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BotsController : ControllerBase
    {
        private readonly IBotService _botService;

        private readonly IMapper _mapper;

        private readonly IHubContext<NotifyHub, ITypedHubClient> _hubContext;

        public BotsController(IBotService botService, IMapper mapper, IHubContext<NotifyHub, ITypedHubClient> hubContext)
        {
            _botService = botService;
            _mapper = mapper;
            _hubContext = hubContext;
        }

        // PUT: api/Bots/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBot(int id, [FromBody]BotDto botDto)
        {
            botDto.BotId = id;
            try
            {
                var updatedBotStatus = await _botService.UpdateBotAsync(_mapper.Map<Bot>(botDto));

                await _hubContext.Clients.All.BotUpdate("PUT", JsonConvert.SerializeObject(botDto));

                return Ok(updatedBotStatus);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Bots
        [HttpPost]
        public async Task<ActionResult> CreateBot([FromBody]BotDto botDto)
        {
            try
            {
                var bot = _mapper.Map<Bot>(botDto);
                await _botService.CreateNewBotAsync(bot);

                await _hubContext.Clients.All.BotUpdate("POST", JsonConvert.SerializeObject(_mapper.Map<BotDto>(bot)));

                return Ok(_mapper.Map<BotDto>(bot));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Bots/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBot(int id)
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
            try
            {
                var bots = await _botService.GetAllBotsAsync();

                var botsToReturn = _mapper.Map<List<BotDto>>(bots);

                return Ok(botsToReturn);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Bots/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BotDto>> GetBotById(int id)
        {
            try
            {
                var bot = await _botService.GetBotByIdAsync(id);

                return Ok(_mapper.Map<BotDto>(bot));
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
