using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Acorn.BL.Models;
using Acorn.BL.Services;
using AcornAPI.Dtos;
using AcornAPI.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AcornAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        private readonly IMapper _mapper;

        public AccountsController(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }

        // PUT: api/Accounts/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAccount(int id, [FromBody]AccountDto accountDto)
        {
            accountDto.AccountId = id;
            try
            {
                await _accountService.UpdateAccountAsync(_mapper.Map<Account>(accountDto));
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Accounts
        [HttpPost]
        public async Task<ActionResult> CreateAccount([FromBody]AccountDto accountDto)
        {
            try
            {
                await _accountService.CreateNewAccountAsync(_mapper.Map<Account>(accountDto));
                //return CreatedAtAction(nameof(GetAccountById), new { AccountId = account.AccountId }, account);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Accounts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAccount(int id)
        {
            try
            {
                await _accountService.DeleteAccountAsync(id);
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

        // GET: api/Accounts
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult> GetAllAccounts()
        {
            var accounts = await _accountService.GetAllAccountsAsync();

            var accountsToReturn = _mapper.Map<List<AccountDto>>(accounts);

            return Ok(accountsToReturn);
        }

        // GET: api/Accounts/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<AccountDto>> GetAccountById(int id)
        {
            try
            {
                var account = await _accountService.GetAccountByIdAsync(id);

                return Ok(_mapper.Map<AccountDto>(account));
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: api/Accounts/5
        [HttpGet("Bot/{id:int}")]
        public async Task<ActionResult> GetAllAccountsByBotId(int id)
        {
            var accounts = await _accountService.GetAllAccountsByBotIdAsync(id);

            var accountsToReturn = _mapper.Map<List<AccountDto>>(accounts);

            return Ok(accountsToReturn);
        }

        // POST: api/Accounts/5/MarkAsDone
        [HttpPost("{id:int}/MarkAsDone")]
        public async Task<ActionResult> MarkAccountAsDone(int id)
        {
            try
            {
                await _accountService.MarkAccountAsDoneAsync(id);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Accounts/5/RequestAccount
        [HttpPost("{id:int}/RequestAccount")]
        public async Task<ActionResult> RequestAccount(int id, [FromBody]RequestAccountQuery query)
        {
            try
            {
                await _accountService.RequestAccountAsync(id, query.Region);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PATCH: api/Accounts/5
        [HttpPatch("{id:int}")]
        public async Task<ActionResult> UpdateLevelingProgress(int id, [FromBody]UpdateLevelingProgressQuery query)
        {
            try
            {
                await _accountService.UpdateLevelingProgressAsync(id, query.Level, query.ExpPercentage);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
