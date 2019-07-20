using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<long> AddFreshAccountAsync(FreshAccount freshAccount)
        {
            _context.FreshAccounts.Add(freshAccount);
            await _context.SaveChangesAsync();

            long addedId = freshAccount.FreshAccountId;

            return addedId;
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
                throw new InvalidOperationException("FreshAccount does not exist");
            }
        }

        public async Task<IEnumerable<FreshAccount>> GetAllAsync()
        {
            var freshAccounts = from f in _context.FreshAccounts select f;
            return await _context.FreshAccounts.ToListAsync();
        }

        public async Task<FreshAccount> GetFreshAccountByIdAsync(long freshAccountId)
        {
            return await _context.FreshAccounts.FirstOrDefaultAsync(f => f.FreshAccountId == freshAccountId);
        }

        public async Task UpdateFreshAccountAsync(FreshAccount freshAccount)
        {
            var freshAccountToUpdate = await GetFreshAccountByIdAsync(freshAccount.FreshAccountId);

            if (freshAccountToUpdate != null)
            {
                _context.Update(freshAccount);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("FreshAccount does not exist");
            }
        }
    }
}
