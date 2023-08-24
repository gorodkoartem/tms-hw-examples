using System.Reflection;

namespace ConsoleApp2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{nameof(Main)} method from {GetAssemblyName()}");
        }

        private static void SayHello()
        {
            Console.WriteLine($"{nameof(SayHello)} method from {GetAssemblyName()}");
        }

        private static string GetAssemblyName()
        {
            var assembly = Assembly.GetAssembly(typeof(Program));
            return assembly.GetName().Name;
        }
    }
}