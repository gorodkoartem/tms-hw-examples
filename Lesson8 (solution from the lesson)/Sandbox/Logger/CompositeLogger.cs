namespace Sandbox.Logger
{
    internal class CompositeLogger : ILogger
    {
        private readonly ILogger[] _loggers;

        public CompositeLogger(params ILogger[] loggers)
        {
            _loggers = loggers;
        }

        public void Log(string message)
        {
            foreach (var logger in _loggers)
            {
                logger.Log(message);
            }
        }
    }
}
