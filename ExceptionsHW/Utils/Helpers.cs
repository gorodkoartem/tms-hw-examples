namespace ExceptionsHW.Utils
{
    internal static class Helpers
    {
        public static bool ContainsDigit(this string source)
        {
            foreach(var c in source)
            {
                if (char.IsDigit(c))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
