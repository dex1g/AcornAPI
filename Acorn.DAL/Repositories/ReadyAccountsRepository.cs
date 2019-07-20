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

        public async Task<long> AddReadyAccountAsync(ReadyAccount readyAccount)
        {
            _context.ReadyAccounts.Add(readyAccount);
            await _context.SaveChangesAsync();

            long addedId = readyAccount.ReadyAccountId;

            return addedId;
        }

        public async Task DeleteReadyAccountAsync(long readyAccountId)
        {
            var readyAccountToDelete = await GetReadyAccountByIdAsync(readyAccountId);

            if (readyAccountToDelete != null)
            {
                _context.ReadyAccounts.Remove(readyAccountToDelete);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("ReadyAccount does not exist");
            }
        }

        public async Task<IEnumerable<ReadyAccount>> GetAllAsync()
        {
            return await _context.ReadyAccounts.ToListAsync();
        }

        public async Task<ReadyAccount> GetReadyAccountByIdAsync(long readyAccountId)
        {
            return await _context.ReadyAccounts.FirstOrDefaultAsync(f => f.ReadyAccountId == readyAccountId);
        }

        public async Task UpdateReadyAccountAsync(ReadyAccount readyAccount)
        {
            var readyAccountToUpdate = await GetReadyAccountByIdAsync(readyAccount.ReadyAccountId);

            if (readyAccountToUpdate != null)
            {
                _context.Update(readyAccount);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("ReadyAccount does not exist");
            }
        }
    }
}
