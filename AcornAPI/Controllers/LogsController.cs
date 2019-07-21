using System;
using System.Threading.Tasks;
using AutoMapper;
using Acorn.BL.Models;
using Acorn.BL.Services;
using Microsoft.AspNetCore.Mvc;

namespace AcornAPI.Controllers
{
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
            var log = await _logService.GetLatestLogByBotId(id);

            return Ok(log);
        }

        // GET: api/Logs/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Log>> GetAllLogsByBotId(int id)
        {
            try
            {
                var logs = await _logService.GetAllLogsByBotIdAsync(id);

                return Ok(logs);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
