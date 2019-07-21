using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Acorn.BL.Models;
using Acorn.BL.RepositoriesInterfaces;
using Acorn.BL.Validators;

namespace Acorn.BL.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountsRepository _accountsRepository;

        public AccountService(IAccountsRepository accountsRepository)
        {
            _accountsRepository = accountsRepository;
        }

        public async Task CreateNewAccountAsync(Account account)
        {
            await _accountsRepository.AddAccountAsync(account);
        }

        public async Task DeleteAccountAsync(long accountId)
        {
            await _accountsRepository.DeleteAccountAsync(accountId);
        }

        public async Task<IEnumerable<Account>> GetAllAccountsAsync()
        {
            return await _accountsRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Account>> GetAllAccountsByBotIdAsync(long botId)
        {
            return await _accountsRepository.GetAllByBotIdAsync(botId);
        }

        public async Task<Account> GetAccountByIdAsync(long accountId)
        {
            return await _accountsRepository.GetAccountByIdAsync(accountId);
        }

        public async Task UpdateAccountAsync(Account account)
        {
            if (!AccountValidator.ValidateDefault(account))
            {
                throw new InvalidOperationException("Account's validation failed");
            }

            await _accountsRepository.UpdateAccountAsync(account);
        }

        public async Task MarkAccountAsDoneAsync(long accountId)
        {
            await _accountsRepository.MarkAccountAsDoneAsync(accountId);
        }
    }
}
