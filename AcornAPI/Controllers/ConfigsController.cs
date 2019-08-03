using System;
using System.Threading.Tasks;
using AutoMapper;
using Acorn.BL.Models;
using Acorn.BL.Services;
using AcornAPI.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AcornAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigsController : ControllerBase
    {
        private readonly IConfigService _configService;

        private readonly IMapper _mapper;

        public ConfigsController(IConfigService configService, IMapper mapper)
        {
            _configService = configService;
            _mapper = mapper;
        }

        // PUT: api/Configs
        [HttpPut]
        public async Task<ActionResult> UpdateConfig([FromBody]ConfigDto configDto)
        {
            try
            {
                await _configService.UpdateConfigAsync(_mapper.Map<Config>(configDto));
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Congifs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConfigDto>> GetConfigById(int id)
        {
            try
            {
                var config = await _configService.GetConfigByIdAsync(id);

                return Ok(_mapper.Map<ConfigDto>(config));
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
