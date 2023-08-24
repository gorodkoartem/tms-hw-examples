namespace Sandbox.Builder
{
    internal abstract class Builder
    {
        protected int state;

        public int State => state;

        public Builder(int state) { this.state = state; }

        public void Build()
        {
            BuildFund();
            BuildWalls();
            BuildRoof();
        }

        protected abstract void BuildFund();
        protected abstract void BuildWalls();
        protected abstract void BuildRoof();
    }
}
