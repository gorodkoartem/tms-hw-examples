namespace Sandbox
{
    class BaseClass
    {
        public string Name1 { get; set; }
    }

    class MyClass : BaseClass
    {
        public string Name2 { get; set; }
    }

    class DerivedClass : MyClass
    {
        public string Name3 { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            IMyList<int> myList = new MyList<int>();
            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            myList.Add(4);

            new Stack<int>().Add(1);

            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
        }

        static BaseClass Method1(DerivedClass param)
        {
            var a = param.Name3;
            return new BaseClass();
        }

        static BaseClass Method2(MyClass param)
        {
            return new BaseClass(); 
        }

        static MyClass Method3(BaseClass param)
        {
            return new MyClass();
        }
    }
}