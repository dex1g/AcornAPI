using Acorn.BL.Models;

namespace Acorn.BL.Validators
{
    public static class BotValidator
    {
        public static bool ValidateDefault(Bot bot)
        {
            if (bot.BotId > 999)
            {
                return false;
            }

            if (string.IsNullOrEmpty(bot.Nick) || bot.Nick.Length > 20)
            {
                return false;
            }

            return true;
        }
    }
}