using System.Collections.Generic;
using System.Threading.Tasks;
using Acorn.BL.Models;


namespace Acorn.BL.Services
{
    public interface IConfigService
    {
        Task CreateNewConfigAsync(Config config);
        Task DeleteConfigAsync(long botId);
        Task UpdateConfigAsync(Config config);
        Task<IEnumerable<Config>> GetAllConfigsAsync();
        Task<Config> GetConfigByIdAsync(long botId);
    }
}
