using System;
using System.Threading.Tasks;
using Acorn.BL.Models;
using Acorn.BL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AcornAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FreshAccountsController : ControllerBase
    {
        private readonly IFreshAccountService _freshAccountService;

        public FreshAccountsController(IFreshAccountService freshAccountService)
        {
            _freshAccountService = freshAccountService;
        }

        // PUT: api/FreshAccounts/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateFreshAccount(int id, [FromBody]FreshAccount freshAccount)
        {
            freshAccount.FreshAccountId = id;
            try
            {
                await _freshAccountService.UpdateFreshAccountAsync(freshAccount);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/FreshAccounts
        [HttpPost]
        public async Task<ActionResult> CreateFreshAccount([FromBody]FreshAccount freshAccount)
        {
            try
            {
                await _freshAccountService.CreateNewFreshAccountAsync(freshAccount);
                //return CreatedAtAction(nameof(GetFreshAccountById), new { FreshAccountId = freshaccount.FreshAccountId }, freshAccount);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/FreshAccounts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFreshAccount(int id)
        {
            try
            {
                await _freshAccountService.DeleteFreshAccountAsync(id);
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

        // GET: api/FreshAccounts
        [HttpGet]
        public async Task<ActionResult> GetAllFreshAccounts()
        {
            var freshAccounts = await _freshAccountService.GetAllFreshAccountsAsync();

            return Ok(freshAccounts);
        }

        // GET: api/FreshAccounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FreshAccount>> GetFreshAccountById(int id)
        {
            try
            {
                var freshAccount = await _freshAccountService.GetFreshAccountByIdAsync(id);

                return Ok(freshAccount);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
