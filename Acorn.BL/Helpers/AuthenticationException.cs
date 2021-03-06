using System;
using System.Globalization;

namespace Acorn.BL.Helpers
{
    // Custom exception class for throwing JWT authentication specific exceptions
    public class AuthenticationException : Exception
    {
        public AuthenticationException() : base() { }

        public AuthenticationException(string message) : base(message) { }

        public AuthenticationException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}