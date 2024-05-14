using Agenda.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;

namespace Agenda.Logging.Logger
{
    public class CustomLoggerProvider : ILoggerProvider
    {
        private readonly CustomLoggerProviderConfiguration _loggerConfiguration;
        private readonly ConcurrentDictionary<string, CustomLogger> _loggers = new ConcurrentDictionary<string, CustomLogger>();
        private readonly IUnitOfWork _unitOfWork;

        public CustomLoggerProvider(CustomLoggerProviderConfiguration loggerConfiguration, IUnitOfWork unitOfWork)
        {
            _loggerConfiguration = loggerConfiguration;
            _unitOfWork = unitOfWork;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return _loggers.GetOrAdd(categoryName, name => new CustomLogger(name, _loggerConfiguration, _unitOfWork));
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
