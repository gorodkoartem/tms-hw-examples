using System.Reflection;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var asm = Assembly.LoadFrom("ConsoleApp2.dll");
            var program = asm.GetType("ConsoleApp2.Program");

            var main = program.GetMethod("Main", BindingFlags.NonPublic | BindingFlags.Static);
            main.Invoke(null, new object[] { new string[] { } });

            var sayHello = program.GetMethod("SayHello", BindingFlags.NonPublic | BindingFlags.Static);
            sayHello.Invoke(null, null);
        }
    }
}