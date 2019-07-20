using Acorn.BL.Models;

namespace Acorn.BL.Validators
{
    public static class BotValidator
    {
        public static bool ValidateDefault(Bot bot)
        {
            return bot.BotId <= 999 && bot.BotId >= 0;
        }
    }
}