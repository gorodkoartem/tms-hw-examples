namespace ExceptionsHW.Exceptions
{
    internal class WrongPasswordException : Exception
    {
        public WrongPasswordException() : base() { }

        public WrongPasswordException(string message) : base(message) { }
    }
}
