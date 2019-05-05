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

        public async Task DeleteAccountAsync(long botId)
        {
            var accountToDelete = await GetAccountByIdAsync(botId);

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

        public async Task<Account> GetAccountByIdAsync(long botId)
        {
            return await _context.Accounts.FirstOrDefaultAsync(a => a.BotId == botId);
        }

        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task UpdateAccountAsync(Account account)
        {
            var accountToUpdate = await GetAccountByIdAsync(account.BotId);

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
