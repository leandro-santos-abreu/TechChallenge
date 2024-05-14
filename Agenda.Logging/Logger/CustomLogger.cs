using Agenda.Domain.Entities;
using Agenda.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace Agenda.Logging.Logger
{
    public class CustomLogger(string loggerName, CustomLoggerProviderConfiguration loggerConfiguration, IUnitOfWork unitOfWork) : ILogger<CustomLogger>
    {
        private readonly string _loggerName = loggerName;
        private readonly CustomLoggerProviderConfiguration _loggerConfiguration = loggerConfiguration;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            string message = $"Log de Execução: {logLevel}: {eventId} - {formatter(state, exception)}";
            Console.WriteLine(message);

            LogEntity log = new()
            {
                LogLevel = logLevel.ToString(),
                Description = message
            };

            _unitOfWork.Logs.SaveAsync(log, CancellationToken.None);
            _unitOfWork.CompleteAsync(CancellationToken.None);
        }
    }
}
