using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acorn.BL.Models;
using Acorn.BL.RepositoriesInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Acorn.DAL.Repositories
{
    public class ReadyAccountsRepository : IReadyAccountsRepository
    {
        private readonly DatabaseContext _context;

        public ReadyAccountsRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<ReadyAccount> AddReadyAccountAsync(ReadyAccount readyAccount)
        {
            _context.ReadyAccounts.Add(readyAccount);
            await _context.SaveChangesAsync();
            return readyAccount;
        }

        public async Task DeleteReadyAccountAsync(long readyAccountId)
        {
            var readyAccountToDelete = await _context.ReadyAccounts.FirstOrDefaultAsync(f => f.ReadyAccountId == readyAccountId);

            if (readyAccountToDelete != null)
            {
                _context.ReadyAccounts.Remove(readyAccountToDelete);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException(Resources.ReadyAccNotExistString);
            }
        }

        public async Task<IEnumerable<ReadyAccount>> GetAllAsync()
        {
            return await _context.ReadyAccounts.OrderBy(a => a.ReadyAccountId).ToListAsync();
        }

        public async Task<ReadyAccount> GetReadyAccountByIdAsync(long readyAccountId)
        {
            return await _context.ReadyAccounts.FirstOrDefaultAsync(f => f.ReadyAccountId == readyAccountId);
        }

        public async Task UpdateReadyAccountAsync(ReadyAccount readyAccount)
        {
            var exists = await _context.ReadyAccounts.AnyAsync(f => f.ReadyAccountId == readyAccount.ReadyAccountId);

            if (exists)
            {
                _context.ReadyAccounts.Update(readyAccount);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException(Resources.ReadyAccNotExistString);
            }
        }
    }
}
