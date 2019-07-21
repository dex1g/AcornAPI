﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Acorn.BL.Models;


namespace Acorn.BL.Services
{
    public interface IAccountService
    {
        Task CreateNewAccountAsync(Account account);
        Task DeleteAccountAsync(long accountId);
        Task UpdateAccountAsync(Account account);
        Task<IEnumerable<Account>> GetAllAccountsAsync();
        Task<IEnumerable<Account>> GetAllAccountsByBotIdAsync(long botId);
        Task<Account> GetAccountByIdAsync(long accountId);
    }
}
