using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Acorn.BL.Models;
using Acorn.BL.Services;
using AcornAPI.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

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

        // POST: api/Logs
        [HttpPost]
        public async Task<ActionResult> CreateLog([FromBody]Log log)
        {
            try
            {
                await _logService.CreateNewLogAsync(log);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Logs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLog(int id)
        {
            try
            {
                await _logService.DeleteLogAsync(id);
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

        // GET: api/Logs
        [HttpGet("{id:int}/Latest")]
        public async Task<ActionResult> GetLatestLogByBotId(int id)
        {
            try
            {
                var log = await _logService.GetLatestLogByBotId(id);
                return Ok(_mapper.Map<LogDto>(log));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Logs/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Log>> GetAllLogsByBotId(int id)
        {
            try
            {
                var logs = await _logService.GetAllLogsByBotIdAsync(id);
                var logsToReturn = _mapper.Map<List<LogDto>>(logs);
                return Ok(logsToReturn);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
