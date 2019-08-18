using System.Collections.Generic;
using System.Threading.Tasks;
using Acorn.BL.Models;


namespace Acorn.BL.Services
{
    public interface IFreshAccountService
    {
        Task<FreshAccount> CreateNewFreshAccountAsync(FreshAccount freshAccount);
        Task DeleteFreshAccountAsync(long freshAccountId);
        Task UpdateFreshAccountAsync(FreshAccount freshAccount);
        Task<IEnumerable<FreshAccount>> GetAllFreshAccountsAsync();
        Task<FreshAccount> GetFreshAccountByIdAsync(long freshAccountId);
    }
}
