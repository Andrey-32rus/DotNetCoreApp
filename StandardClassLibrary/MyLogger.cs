using System;
using System.Collections.Generic;
using System.Text;
using NLog;
using NLog.Fluent;

namespace StandardClassLibrary
{
    public static class MyLogger
    {
        private static readonly Logger Logger= LogManager.GetLogger("MyLogger");

        public static void Log(string text)
        {
            Logger.Log(LogLevel.Error).Message(text).Write();
        }
    }
}
