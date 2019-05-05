using System.Collections.Generic;
using System.Threading.Tasks;
using Acorn.BL.Models;


namespace Acorn.BL.Services
{
    public interface IBotOrderService
    {
        Task CreateNewBotOrderAsync(BotOrder botOrder);
        Task DeleteBotOrderAsync(long botId);
        Task UpdateBotOrderAsync(BotOrder botOrder);
        Task<IEnumerable<BotOrder>> GetAllBotOrdersAsync();
        Task<BotOrder> GetBotOrderByIdAsync(long botId);
    }
}
