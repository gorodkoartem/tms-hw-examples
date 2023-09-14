namespace GenericsHW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            stack.Pop();

            stack.Push(4);



            var element = stack.Peek();

            if(!stack.IsEmpty)
            {
                element = stack.Pop();
            }

        }
    }
}