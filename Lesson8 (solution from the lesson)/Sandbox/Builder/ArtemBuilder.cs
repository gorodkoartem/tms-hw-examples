namespace Sandbox.Builder
{
    internal class ArtemBuilder : Builder
    {
        public ArtemBuilder(int state) : base(state) { }

        protected override void BuildFund()
        {
            Console.WriteLine("Build fund from zhelezo");
        }

        protected override void BuildRoof()
        {
            Console.WriteLine("Build roof from cherepica");
        }

        protected override void BuildWalls()
        {
            Console.WriteLine("Build walls from derevo");
        }
    }
}
