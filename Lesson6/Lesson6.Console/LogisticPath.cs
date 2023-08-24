namespace Lesson6.Console
{
    internal class LogisticPath
    {
        private const int SecondsPerKm = 30;

        protected virtual double AverageSecondsPerKm => SecondsPerKm;

        public string From { get; }
        public string To { get; }

        public LogisticPath(string from, string to)
        {
            From = from;
            To = to;
        }

        public virtual TimeSpan EstimateDuration()
        {
            return TimeSpan.FromSeconds(AverageSecondsPerKm * GetDistanceKm());
        }

        protected virtual double GetDistanceKm()
        {
            // Here should be real calculations
            return new Random().Next();
        }
    }
}
