using Sandbox.Logger;

namespace Sandbox
{
    internal class Service
    {
        private readonly ILogger _logger;
        private readonly Builder.Builder _builder;
        private int _i = 0;

        public Service(ILogger logger, Builder.Builder builder)
        {
            _logger = logger ?? throw new ArgumentNullException();
            _builder = builder;
        }

        public void DoThings()
        {
            _logger.Log($"{nameof(DoThings)} started: i = {_i}");
            _i++;
            _logger.Log($"{nameof(DoThings)} finished: i = {_i}");
        }

        public void BuildHouse()
        {
            _builder.Build();
            var a = _builder.State;
        }
    }
}
