using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace Logging.LogHelper
{
    public class Logger : ILogger
    {
        [Obsolete]
        IHostingEnvironment _hostingEnvironment;

        [Obsolete]
        public Logger(IHostingEnvironment hostingEnvironment) => _hostingEnvironment = hostingEnvironment;
        public IDisposable BeginScope<TState>(TState state) => null;
        public bool IsEnabled(LogLevel logLevel) => true;

        [Obsolete]
        public async void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            using (StreamWriter streamWriter = new StreamWriter($"{_hostingEnvironment.ContentRootPath}/log.txt", true))
            {
                await streamWriter.WriteLineAsync($"Log Level : {logLevel.ToString()} | Event ID : {eventId.Id} | Event Name : {eventId.Name} | Formatter : {formatter(state, exception)} | DateTime : {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}");
                streamWriter.Close();
                await streamWriter.DisposeAsync();
            }
        }
    }
}
