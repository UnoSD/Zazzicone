using System.Windows.Forms;

namespace Launcher
{
    public class Logger : ILogger
    {
        public void Log(LogLevel logLevel, string message) => MessageBox.Show(message);
    }
}