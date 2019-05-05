using System.Collections.Generic;
using System.Threading.Tasks;
using Acorn.BL.Models;


namespace Acorn.BL.Services
{
    public interface IReadyAccountService
    {
        Task<long> CreateNewReadyAccountAsync(ReadyAccount readyAccount);
        Task DeleteReadyAccountAsync(long readyAccountId);
        Task UpdateReadyAccountAsync(ReadyAccount readyAccount);
        Task<IEnumerable<ReadyAccount>> GetAllReadyAccountsAsync();
        Task<ReadyAccount> GetReadyAccountByIdAsync(long readyAccountId);
    }
}
