using System.Collections.Generic;
using System.Threading.Tasks;
using Acorn.BL.Models;


namespace Acorn.BL.RepositoriesInterfaces
{
    public interface IBotsRepository
    {
        Task AddBotAsync(Bot bot);
        Task DeleteBotAsync(long botId);
        Task UpdateBotAsync(Bot bot);
        Task<IEnumerable<Bot>> GetAllAsync();
        Task<Bot> GetBotByIdAsync(long botId);
    }
}
