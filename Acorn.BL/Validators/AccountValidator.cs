using System;
using Acorn.BL.Models;

namespace Acorn.BL.Validators
{
    public static class AccountValidator
    {
        public static bool ValidateDefault(Account account)
        {
            if (string.IsNullOrEmpty(account.Login))
            {
                return false;
            }

            if (string.IsNullOrEmpty(account.Password))
            {
                return false;
            }

            if (DateTime.Compare(DateTime.Parse(account.BirthDate), DateTime.Now) > 0)
            {
                return false;
            }

            return true;
        }

        public static bool ValidateDefault(FreshAccount freshAccount)
        {
            return ValidateDefault(new Account { Login = freshAccount.Login, Password = freshAccount.Password, BirthDate = freshAccount.BirthDate });
        }

        public static bool ValidateDefault(ReadyAccount readyAccount)
        {
            return ValidateDefault(new Account { Login = readyAccount.Login, Password = readyAccount.Password, BirthDate = readyAccount.BirthDate });
        }
    }
}