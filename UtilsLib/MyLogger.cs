using NLog;
using NLog.Fluent;

namespace UtilsLib
{
    public static class MyLogger
    {
        private static readonly Logger Logger = LogManager.GetLogger("MyLogger");

        public static void Log(string text, LogLevel logLevel)
        {
            Logger.Log(LogLevel.Error).Message(text).Write();
        }
    }
}
