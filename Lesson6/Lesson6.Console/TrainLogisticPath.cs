namespace Lesson6.Console
{
    internal class TrainLogisticPath : LandLogisticPath
    {
        public int LoadingDelayMinutes { get; }

        public TrainLogisticPath(string from, string to, int loadingDelayMinutes = 0) : base(from, to)
        {
            LoadingDelayMinutes = loadingDelayMinutes;
        }

        public TimeSpan EstimateDuration()
        {
            return base.EstimateDuration().Add(TimeSpan.FromMinutes(0));
        }
    }
}
