using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PolandDelivery.Models;

namespace PolandDelivery.LoggerHelper
{
    public class DBLoggerProvider : ILoggerProvider
    {
        private ILogger _dbLogger;

        public DBLoggerProvider(ILogger dbLogger) => _dbLogger = dbLogger;

        public ILogger CreateLogger(string categoryName) => _dbLogger;

        public void Dispose()
        { }
    }
}
