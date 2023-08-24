using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6.Console
{
    internal class WaterLogisticPath : LogisticPath
    {
        private const int SecondsPerKm = 40;
        private const int StormDelayHours = 12;

        protected override double AverageSecondsPerKm => SecondsPerKm;

        public bool IsStormExpected { get; }

        public WaterLogisticPath(string from, string to, bool isStormExpected = false) : base(from, to)
        {
            IsStormExpected = isStormExpected;
        }

        public override TimeSpan EstimateDuration()
        {
            var estimatedDuration = base.EstimateDuration();
            if (IsStormExpected)
            {
                estimatedDuration = estimatedDuration.Add(TimeSpan.FromHours(StormDelayHours));
            }

            return estimatedDuration;
        }

        protected override double GetDistanceKm()
        {
            return base.GetDistanceKm() * 1.5;
        }
    }
}
