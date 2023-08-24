namespace Lesson6.Console
{
    // inheritance example
    // пример наследования
    internal class LandLogisticPath : LogisticPath
    {
        private const double StopsPerKm = 0.0001;
        private const int SecondsPerStop = 1600;
        private const int SecondsPerKm = 60;

        // Overriding protected virtual property
        // Переопределение протектед виртального свойства
        protected override double AverageSecondsPerKm => (StopsPerKm * SecondsPerStop) + SecondsPerKm;

        public int StopsCount { get; }

        // Constructor with parameters and base constructor call
        // Конструктор с параметрами с вызовом конструктора базового класса
        public LandLogisticPath(string from, string to, int stopsCount = 0) : base(from, to)
        {
            StopsCount = stopsCount;
        }

        // Overriding protected method
        // Переопределение протектед метода
        protected override double GetDistanceKm()
        {
            return base.GetDistanceKm() * 2;
        }
    }
}
