using System.Collections.Generic;
using System.Threading.Tasks;
using Acorn.BL.Models;


namespace Acorn.BL.Services
{
    public interface IAccountService
    {
        Task CreateNewAccountAsync(Account account);
        Task DeleteAccountAsync(long botId);
        Task UpdateAccountAsync(Account account);
        Task<IEnumerable<Account>> GetAllAccountsAsync();
        Task<Account> GetAccountByIdAsync(long botId);
    }
}
