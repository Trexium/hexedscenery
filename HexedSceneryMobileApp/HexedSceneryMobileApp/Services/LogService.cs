using HexedSceneryMobileApp.Enums;
using HexedSceneryMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexedSceneryMobileApp.Services
{
    
    public interface ILogService
    {
        LogLevel CurrentLogLevel { get; }
        Task TraceAsync(string message);
        Task DebugAsync(string message);
        Task InfoAsync(string message);
        Task WarnAsync(string message);
        Task ErrorAsync(string message, Exception exception = null);
        Task FatalAsync(string message, Exception exception = null);
        Task<IEnumerable<Log>> GetLogs(LogLevel logLevel);
        Task<Log> GetLatest(LogLevel logLevel);
    }
    public class LogService : ILogService
    {
        private readonly Dictionary<LogLevel, Stack<Log>> _logs;
        private Log _latestLog;

        public LogService(LogLevel logLevel)
        {
            CurrentLogLevel = logLevel;
            _logs = new Dictionary<LogLevel, Stack<Log>>();

            foreach (var level in Enum.GetValues(typeof(LogLevel)).Cast<LogLevel>())
            {
                _logs.Add(level, new Stack<Log>());
            }
        }

        public LogLevel CurrentLogLevel { get; private set; }

        public async Task<IEnumerable<Log>> GetLogs(LogLevel logLevel)
        {
            return _logs[logLevel];
        }

        public async Task<Log> GetLatest(LogLevel logLevel)
        {
            return _logs[logLevel].Peek();
        }

        public async Task DebugAsync(string message)
        {
            if (((int)CurrentLogLevel) <= (int)LogLevel.Debug)
                Log(LogLevel.Debug, message);
        }

        public async Task ErrorAsync(string message, Exception exception = null)
        {
            if (((int)CurrentLogLevel) <= (int)LogLevel.Error)
                Log(LogLevel.Error, message, exception);
        }

        public async Task FatalAsync(string message, Exception exception = null)
        {
            Log(LogLevel.Fatal, message, exception);
        }

        public async Task InfoAsync(string message)
        {
            if (((int)CurrentLogLevel) <= (int)LogLevel.Info)
                Log(LogLevel.Info, message);
        }

        public async Task TraceAsync(string message)
        {
            if (((int)CurrentLogLevel) <= (int)LogLevel.Trace)
                Log(LogLevel.Trace, message);
        }

        public async Task WarnAsync(string message)
        {
            if (((int)CurrentLogLevel) <= (int)LogLevel.Warn)
                Log(LogLevel.Warn, message);
        }


        private void Log(LogLevel logLevel, string message, Exception exception = null)
        {
            _logs[logLevel].Push(new Log(logLevel, message, exception));
        }
    }
}
