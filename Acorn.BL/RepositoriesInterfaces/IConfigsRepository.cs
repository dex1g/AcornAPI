using System.Collections.Generic;
using System.Threading.Tasks;
using Acorn.BL.Models;


namespace Acorn.BL.RepositoriesInterfaces
{
    public interface IConfigsRepository
    {
        Task AddConfigAsync(Config config);
        Task DeleteConfigAsync(long botId);
        Task UpdateConfigAsync(Config config);
        Task<IEnumerable<Config>> GetAllAsync();
        Task<Config> GetConfigByIdAsync(long botId);
    }
}
