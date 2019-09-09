using NLog;
using NLog.Fluent;

namespace UtilsLib
{
    public static class MyLogger
    {
        private static readonly Logger Logger = LogManager.GetLogger("MyLogger");

        public static void Log(string text, LogLevel logLevel, string path = null)
        {
            Logger
                .Log(LogLevel.Error)
                .Message(text)
                .Property("Path",path)
                .Write();
        }
    }
}
