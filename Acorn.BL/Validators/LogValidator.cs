using Acorn.BL.Models;
using System;

namespace Acorn.BL.Validators
{
    public static class LogValidator
    {
        public static bool ValidateDefault(Log log)
        {
            if (string.IsNullOrEmpty(log.Status) || log.Status.Length > 100)
            {
                return false;
            }

            if (DateTime.Compare(DateTime.Parse(log.Date), DateTime.Now) > 0)
            {
                return false;
            }

            return true;
        }
    }
}