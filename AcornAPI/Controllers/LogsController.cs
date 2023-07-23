using System;
using System.Threading.Tasks;
using Acorn.BL.Services;
using AcornAPI.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using AcornAPI.Queries;

namespace AcornAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly ILogService _logService;
        private readonly IMapper _mapper;

        public LogsController(ILogService logService, IMapper mapper)
        {
            _logService = logService;
            _mapper = mapper;
        }

        // PUT: api/Logs
        [AllowAnonymous]
        [HttpPut("{botId:int}")]
        public async Task<ActionResult> UpdateLog(int botId, [FromBody]UpdateLogQuery log)
        {
            try
            {
                await _logService.UpdateLogAsync(botId, log.Status, log.Date);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Logs
        [HttpGet("{botId:int}/Latest")]
        public async Task<ActionResult> GetLogByBotId(int botId)
        {
            try
            {
                var log = await _logService.GetLogByBotId(botId);
                return Ok(_mapper.Map<LogDto>(log));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
