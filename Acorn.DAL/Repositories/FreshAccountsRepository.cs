using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Acorn.BL.Models;
using Acorn.BL.RepositoriesInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Acorn.DAL.Repositories
{
    public class FreshAccountsRepository : IFreshAccountsRepository
    {
        private readonly DatabaseContext _context;

        public FreshAccountsRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<FreshAccount> AddFreshAccountAsync(FreshAccount freshAccount)
        {
            _context.FreshAccounts.Add(freshAccount);
            await _context.SaveChangesAsync();
            return freshAccount;
        }

        public async Task DeleteFreshAccountAsync(long freshAccountId)
        {
            var freshAccountToDelete = await GetFreshAccountByIdAsync(freshAccountId);

            if (freshAccountToDelete != null)
            {
                _context.FreshAccounts.Remove(freshAccountToDelete);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException(Resources.FreshAccNotExistString);
            }
        }

        public async Task<IEnumerable<FreshAccount>> GetAllAsync()
        {
            return await _context.FreshAccounts.ToListAsync();
        }

        public async Task<FreshAccount> GetFreshAccountByIdAsync(long freshAccountId)
        {
            return await _context.FreshAccounts.FirstOrDefaultAsync(f => f.FreshAccountId == freshAccountId);
        }

        public async Task UpdateFreshAccountAsync(FreshAccount freshAccount)
        {
            var exists = await _context.FreshAccounts.AnyAsync(f => f.FreshAccountId == freshAccount.FreshAccountId);

            if (exists)
            {
                _context.FreshAccounts.Update(freshAccount);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException(Resources.FreshAccNotExistString);
            }
        }
    }
}
