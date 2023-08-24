namespace Lesson6.Console
{
    internal class LandLogisticPath : LogisticPath
    {
        private const double StopsPerKm = 0.0001;
        private const int SecondsPerStop = 1600;
        private const int SecondsPerKm = 60;

        protected override double AverageSecondsPerKm => (StopsPerKm * SecondsPerStop) + SecondsPerKm;

        public int StopsCount { get; }

        public LandLogisticPath(string from, string to, int stopsCount = 0) : base(from, to)
        {
            StopsCount = stopsCount;
        }

        protected override double GetDistanceKm()
        {
            return base.GetDistanceKm() * 2;
        }
    }
}
