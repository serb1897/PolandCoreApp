using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PolandDelivery.Models;
using System.IO;

namespace PolandDelivery.FileLogger
{
    public class FileLoggerProvider : ILoggerProvider
    {
        private string _path;

        public FileLoggerProvider(IOptions<AppSettings> appSettings)
        {
            _path = Path.Combine(Directory.GetCurrentDirectory(), appSettings.Value.logPath);
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger(_path);
        }

        public void Dispose()
        { }
    }
}
