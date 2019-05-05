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
            
            if (string.IsNullOrEmpty(config.Champion1) || !Enum.TryParse<Champions>(config.Champion1, true, out _))
            {
                return false;
            }
            
            if (string.IsNullOrEmpty(config.Champion2) || !Enum.TryParse<Champions>(config.Champion2, true, out _))
            {
                return false;
            }
            
            if (string.IsNullOrEmpty(config.Champion3) || !Enum.TryParse<Champions>(config.Champion3, true, out _))
            {
                return false;
            }
            
            if (string.IsNullOrEmpty(config.Champion4) || !Enum.TryParse<Champions>(config.Champion4, true, out _))
            {
                return false;
            }
            
            if (string.IsNullOrEmpty(config.Champion5) || !Enum.TryParse<Champions>(config.Champion5, true, out _))
            {
                return false;
            }

            return true;
        }
    }
}