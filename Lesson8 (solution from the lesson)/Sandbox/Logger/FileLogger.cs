namespace Sandbox.Logger
{
    internal class FileLogger : ILogger
    {
        private readonly string _path;

        public FileLogger(string path)
        {
            _path = path ?? throw new ArgumentNullException(nameof(path));
        }

        public void Log(string message)
        {
            File.AppendAllText(_path, message);
        }
    }
}
