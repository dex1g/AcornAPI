using System.Collections.Generic;
using System.Threading.Tasks;
using Acorn.BL.Enums;
using Acorn.BL.Models;


namespace Acorn.BL.Services
{
    public interface IBotService
    {
        Task CreateNewBotAsync(Bot bot);
        Task DeleteBotAsync(long botId);
        Task<BotOrder> UpdateBotAsync(Bot bot);
        Task<IEnumerable<Bot>> GetAllBotsAsync();
        Task<Bot> GetBotByIdAsync(int botId);
        Task SetAllBotOrdersAsync(BotOrder order);
    }
}
