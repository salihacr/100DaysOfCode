using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace Logging.LogHelper
{
    public class LoggerProvider : ILoggerProvider
    {
        [Obsolete]
        public IHostingEnvironment _hostingEnvironment;

        [Obsolete]
        public LoggerProvider(IHostingEnvironment hostingEnvironment) => _hostingEnvironment = hostingEnvironment;

        [Obsolete]
        public ILogger CreateLogger(string categoryName) => new Logger(_hostingEnvironment);
        public void Dispose() => throw new NotImplementedException();
    }
}
