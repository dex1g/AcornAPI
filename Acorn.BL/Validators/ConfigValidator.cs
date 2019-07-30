using Acorn.BL.Models;

namespace Acorn.BL.Validators
{
    public static class ConfigValidator
    {
        public static bool ValidateDefault(Config config)
        {
            return !string.IsNullOrEmpty(config.Path);
        }
    }
}