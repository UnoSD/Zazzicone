namespace Launcher
{
    public interface ILogger
    {
        void Log(LogLevel logLevel, string message);
    }
}