using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acorn.BL.Enums;
using Acorn.BL.Models;
using Acorn.BL.RepositoriesInterfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Acorn.DAL.Repositories
{
    public class AccountsRepository : IAccountsRepository
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public AccountsRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Account> AddAccountAsync(Account account)
        {
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
            return account;
        }

        public async Task DeleteAccountAsync(long accountId)
        {
            var accountToDelete = await _context.Accounts.FirstOrDefaultAsync(a => a.AccountId == accountId);

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
            var exists = await _context.Accounts.AnyAsync(a => a.AccountId == account.AccountId);

            if (exists)
            {
                _context.Accounts.Update(account);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException(Resources.AccNotExistString);
            }
        }

        public async Task MarkAccountAsDoneAsync(long accountId)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(a => a.AccountId == accountId);
            if (account != null)
            {
                _context.Accounts.Remove(account);
                var readyAccount = _mapper.Map<ReadyAccount>(account);
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
            var freshAccount = await _context.FreshAccounts.FirstOrDefaultAsync(x => x.Region == region);
            if (freshAccount != null)
            {
                _context.FreshAccounts.Remove(freshAccount);
                var account = _mapper.Map<Account>(freshAccount);
                account.BotId = botId;
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
            var account = await _context.Accounts.FirstOrDefaultAsync(x => x.AccountId == accountId);
            if (account != null)
            {
                account.Level = level;
                account.ExpPercentage = expPercentage;
                _context.Accounts.Update(account);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException(Resources.AccNotExistString);
            }
        }

        public async Task DetachAccountAsync(int accountId)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(x => x.AccountId == accountId);
            if (account != null)
            {
                var freshAcc = _mapper.Map<FreshAccount>(account);
                _context.Accounts.Remove(account);
                _context.FreshAccounts.Add(freshAcc);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException(Resources.AccNotExistString);
            }
        }
    }
}
