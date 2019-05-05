using System.Collections.Generic;
using System.Threading.Tasks;
using Acorn.BL.Models;


namespace Acorn.BL.RepositoriesInterfaces
{
    public interface IBotOrdersRepository
    {
        Task AddBotOrderAsync(BotOrder botOrder);
        Task DeleteBotOrderAsync(long botId);
        Task UpdateBotOrderAsync(BotOrder botOrder);
        Task<IEnumerable<BotOrder>> GetAllAsync();
        Task<BotOrder> GetBotOrderByIdAsync(long botId);
    }
}
