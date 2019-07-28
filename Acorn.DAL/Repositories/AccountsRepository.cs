using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acorn.BL.Enums;
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
                throw new InvalidOperationException(Resources.AccNotExistString);
            }
        }

        public async Task<IEnumerable<Account>> GetAllByBotIdAsync(long botId)
        {
            return await _context.Accounts.Where(account => account.BotId == botId).ToListAsync();
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
                throw new InvalidOperationException(Resources.AccNotExistString);
            }
        }

        public async Task MarkAccountAsDoneAsync(long accountId)
        {
            var account = await GetAccountByIdAsync(accountId);
            if (account != null)
            {
                _context.Accounts.Remove(account);
                var readyAccount = new ReadyAccount() { Login = account.Login, Password = account.Password, Region = account.Region, BirthDate = account.BirthDate };
                _context.ReadyAccounts.Add(readyAccount);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException(Resources.AccNotExistString);
            }
        }

        public async Task RequestAccountAsync(int botId, Region region)
        {
            var freshAccount = await _context.FreshAccounts.FirstAsync(x => x.Region == region);
            if (freshAccount != null)
            {
                _context.FreshAccounts.Remove(freshAccount);
                var account = new Account() { Login = freshAccount.Login, Password = freshAccount.Password, BirthDate = freshAccount.BirthDate, Region = freshAccount.Region, BotId = botId };
                _context.Accounts.Add(account);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException(Resources.NoFreshAccInRegionString);
            }
        }

        public async Task UpdateLevelingProgressAsync(int accountId, int level, int expPercentage)
        {
            var account = await _context.Accounts.FirstAsync(x => x.AccountId == accountId);
            if (account != null)
            {
                account.Level = level;
                account.ExpPercentage = expPercentage;
                _context.Accounts.Update(account);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException(Resources.NoFreshAccInRegionString);
            }
        }
    }
}
