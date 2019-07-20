using System;
using Acorn.BL.Helpers;
using Acorn.BL.Models;

namespace Acorn.BL.Validators
{
    public static class ConfigValidator
    {
        public static bool ValidateDefault(Config config)
        {
            if (string.IsNullOrEmpty(config.Queuetype) || !Enum.TryParse<QueueTypes>(config.Queuetype, true, out _))
            {
                return false;
            }

            if (string.IsNullOrEmpty(config.Aiconfig) || !Enum.TryParse<AiConfigs>(config.Aiconfig, true, out _))
            {
                return false;
            }

            if (string.IsNullOrEmpty(config.Path))
            {
                return false;
            }

            return true;
        }
    }
}