using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexedSceneryMobileApp.Services
{
    public enum LogLevel
    {
        Trace = 0,
        Debug = 1,
        Info = 2,
        Warn = 3,
        Error = 4,
        Fatal = 5
    }
    public interface ILogService
    {
        LogLevel LogLevel { get; }
        Task TraceAsync(string  message);
        Task DebugAsync(string message);
        Task InfoAsync(string message);
        Task WarnAsync(string message);
        Task ErrorAsync(string message, Exception exception = null);
        Task FatalAsync(string message, Exception exception = null);
    }
    public class LogService : ILogService
    {
        private readonly Dictionary<LogLevel, List<Log>> _logs;

        public LogService(LogLevel logLevel)
        {
            LogLevel = logLevel;
        }

        public LogLevel LogLevel { get; private set; }

        public Task DebugAsync(string message)
        {
            throw new NotImplementedException();
        }

        public Task ErrorAsync(string message, Exception exception = null)
        {
            throw new NotImplementedException();
        }

        public Task FatalAsync(string message, Exception exception = null)
        {
            throw new NotImplementedException();
        }

        public Task InfoAsync(string message)
        {
            throw new NotImplementedException();
        }

        public Task TraceAsync(string message)
        {
            throw new NotImplementedException();
        }

        public Task WarnAsync(string message)
        {
            throw new NotImplementedException();
        }

        private void Log(LogLevel logLevel, string message, Exception exception = null)
        {

        }
    }

    internal class Log
    {
        internal LogLevel LogLevel { get; private set; }
        internal string Message { get; private set; }
        internal Exception Exception { get; private set; }
    }
}
