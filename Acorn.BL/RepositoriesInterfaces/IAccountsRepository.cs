using System.Collections.Generic;
using System.Threading.Tasks;
using Acorn.BL.Models;


namespace Acorn.BL.RepositoriesInterfaces
{
    public interface IAccountsRepository
    {
        Task AddAccountAsync(Account account);
        Task DeleteAccountAsync(long accountId);
        Task UpdateAccountAsync(Account account);
        Task<IEnumerable<Account>> GetAllAsync();
        Task<IEnumerable<Account>> GetAllByBotIdAsync(long botId);
        Task<Account> GetAccountByIdAsync(long accountId);
        Task MarkAccountAsDoneAsync(long accountId);
    }
}
