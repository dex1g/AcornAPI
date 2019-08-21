using System.Collections.Generic;
using System.Threading.Tasks;
using Acorn.BL.Enums;
using Acorn.BL.Models;


namespace Acorn.BL.RepositoriesInterfaces
{
    public interface IAccountsRepository
    {
        Task<Account> AddAccountAsync(Account account);
        Task DeleteAccountAsync(long accountId);
        Task UpdateAccountAsync(Account account);
        Task<IEnumerable<Account>> GetAllAsync();
        Task<IEnumerable<Account>> GetAllByBotIdAsync(long botId);
        Task<Account> GetAccountByIdAsync(long accountId);
        Task MarkAccountAsDoneAsync(long accountId);
        Task RequestAccountAsync(int botId, Region region);
        Task UpdateLevelingProgressAsync(int accountId, int level, int expPercentage);
        Task DetachAccountAsync(int accountId);
    }
}
