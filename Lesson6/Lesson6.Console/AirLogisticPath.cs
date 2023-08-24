namespace Lesson6.Console
{
    internal class AirLogisticPath : LogisticPath
    {
        private const int SecondsPerKm = 10;
        private const int SecondsPerKmOnRecharge = 5;

        protected override double AverageSecondsPerKm => SecondsPerKm + (RechargeRequired ? SecondsPerKmOnRecharge : 0);

        public bool RechargeRequired { get; }

        public AirLogisticPath(string from, string to, bool rechargeRequired) : base(from, to)
        {
            RechargeRequired = rechargeRequired;
        }
    }
}
