using HexedSceneryMobileApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexedSceneryMobileApp.Models
{
    public class Log
    {
        public Log(LogLevel logLevel, string message, Exception exception)
        {
            LogLevel = logLevel;
            Message = message;
            Exception = exception;
            CreatedAt = DateTime.Now;
        }

        public LogLevel LogLevel { get; private set; }
        public string Message { get; private set; }
        public Exception Exception { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
