using System.Collections.Generic;
using System.Threading.Tasks;
using Acorn.BL.Models;


namespace Acorn.BL.RepositoriesInterfaces
{
    public interface IReadyAccountsRepository
    {
        Task<long> AddReadyAccountAsync(ReadyAccount readyAccount);
        Task DeleteReadyAccountAsync(long readyAccountId);
        Task UpdateReadyAccountAsync(ReadyAccount readyAccount);
        Task<IEnumerable<ReadyAccount>> GetAllAsync();
        Task<ReadyAccount> GetReadyAccountByIdAsync(long readyAccountId);
    }
}
