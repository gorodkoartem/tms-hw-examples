using ExceptionsHW.Exceptions;
using ExceptionsHW.Utils;

namespace ExceptionsHW
{
    internal static class CredentialsValidator
    {
        public static bool ValidateCreadentials(string login, string password, string confirmPassword)
        {
            if(login == null)
            {
                throw new ArgumentNullException(nameof(login));
            }

            if(password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            if (confirmPassword == null)
            {
                throw new ArgumentNullException(nameof(confirmPassword));
            }

            if(!ValidateLogin(login))
            {
                throw new WrongLoginException();
            }

            if (!ValidatePassword(password))
            {
                throw new WrongPasswordException();
            }

            return password == confirmPassword;
        }

        private static bool ValidateLogin(string login)
        {
            return login.Length < 20 && !login.Contains(' ');
        }

        private static bool ValidatePassword(string password)
        {
            return password.Length < 20
                && !password.Contains(' ')
                && password.ContainsDigit();
        }
    }
}
