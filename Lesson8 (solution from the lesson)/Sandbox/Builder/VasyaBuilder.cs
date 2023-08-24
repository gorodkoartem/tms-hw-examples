namespace Sandbox.Builder
{
    internal class VasyaBuilder : Builder
    {
        public VasyaBuilder(int state) : base(state) { }

        protected override void BuildFund()
        {
            Console.WriteLine("Build fund from qwewqeqwe");
        }

        protected override void BuildRoof()
        {
            Console.WriteLine("Build roof from qweqweqwe");
        }

        protected override void BuildWalls()
        {
            Console.WriteLine("Build walls from qweqweqwe");
        }
    }
}
