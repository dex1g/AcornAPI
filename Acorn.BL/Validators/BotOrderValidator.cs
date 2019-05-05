using Acorn.BL.Models;
using Acorn.BL.Helpers;
using System;

namespace Acorn.BL.Validators
{
    public static class BotOrderValidator
    {
        public static bool ValidateDefault(BotOrder botOrder)
        {
            if (string.IsNullOrEmpty(botOrder.Order))
            {
                return false;
            }

            return Enum.TryParse<BotOrders>(botOrder.Order, true, out _);
        }
    }
}