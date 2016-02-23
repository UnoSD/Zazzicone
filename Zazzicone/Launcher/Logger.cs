using System;
using System.Windows.Forms;

namespace Launcher
{
    public class Logger : ILogger
    {
        readonly Action<string> _writer;

        public Logger(Action<string> writer)
        {
            _writer = writer;
        }

        public void Log(LogLevel logLevel, string message) => _writer($"{DateTime.Now} - {logLevel} - {message}");
    }
}