using System.Collections.Generic;
using System.Threading.Tasks;
using Acorn.BL.Models;


namespace Acorn.BL.RepositoriesInterfaces
{
    public interface IFreshAccountsRepository
    {
        Task<FreshAccount> AddFreshAccountAsync(FreshAccount freshAccount);
        Task DeleteFreshAccountAsync(long freshAccountId);
        Task UpdateFreshAccountAsync(FreshAccount freshAccount);
        Task<IEnumerable<FreshAccount>> GetAllAsync();
        Task<FreshAccount> GetFreshAccountByIdAsync(long freshAccountId);
    }
}
