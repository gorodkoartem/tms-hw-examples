namespace Lesson6.Console
{
    // Base class
    internal class LogisticPath
    {
        // private const field with Int32 type
        // приватное константное поле типа Int32
        private const int SecondsPerKm = 30;

        // protected readonly virtual property (only with getter)
        // протектед виртуальное свойство (есть только геттер)
        protected virtual double AverageSecondsPerKm => SecondsPerKm;

        // protected readonly auto-property (only with getter)
        // протектед виртуальное автосвойство (есть только геттер)
        public string From { get; }

        // protected readonly auto-property (only with getter)
        // протектед виртуальное автосвойство (есть только геттер)
        public string To { get; }

        // parametrized constructor
        // конструктор с параметрами
        public LogisticPath(string from, string to)
        {
            From = from;
            To = to;
        }

        // public virtual method 
        // публичный виртуальный метод 
        public virtual TimeSpan EstimateDuration()
        {
            return TimeSpan.FromSeconds(AverageSecondsPerKm * GetDistanceKm());
        }

        // protected virtual method 
        // протектед виртуальный метод 
        protected virtual double GetDistanceKm()
        {
            // Here should be real calculations
            return new Random().Next();
        }
    }
}
