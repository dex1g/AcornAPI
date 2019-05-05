using System.Collections.Generic;
using System.Threading.Tasks;
using Acorn.BL.Models;


namespace Acorn.BL.RepositoriesInterfaces
{
    public interface IAccountsRepository
    {
        Task AddAccountAsync(Account account);
        Task DeleteAccountAsync(long botId);
        Task UpdateAccountAsync(Account account);
        Task<IEnumerable<Account>> GetAllAsync();
        Task<Account> GetAccountByIdAsync(long botId);
    }
}
