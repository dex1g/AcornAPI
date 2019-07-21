using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acorn.BL.Models;
using Acorn.BL.RepositoriesInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Acorn.DAL.Repositories
{
    public class AccountsRepository : IAccountsRepository
    {
        private readonly DatabaseContext _context;

        public AccountsRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task AddAccountAsync(Account account)
        {
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAccountAsync(long accountId)
        {
            var accountToDelete = await GetAccountByIdAsync(accountId);

            if (accountToDelete != null)
            {
                _context.Accounts.Remove(accountToDelete);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Account does not exist");
            }
        }

        public async Task<IEnumerable<Account>> GetAllByBotIdAsync(long botId)
        {
            var accounts = await _context.Accounts.ToListAsync();
            var accountsToReturn = accounts.Where(account => account.BotId == botId);
            return accountsToReturn;
        }

        public async Task<Account> GetAccountByIdAsync(long accountId)
        {
            return await _context.Accounts.FirstOrDefaultAsync(a => a.AccountId == accountId);
        }

        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task UpdateAccountAsync(Account account)
        {
            var accountToUpdate = await GetAccountByIdAsync(account.AccountId);

            if (accountToUpdate != null)
            {
                _context.Update(account);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Account does not exist");
            }
        }
    }
}
