using System;

namespace Logger
{
    class FileLogger : BaseLogger
    {   
        public override void Log(LogLevel logLevel, string message)
        {
            Console.WriteLine(DateTime.Now + " " + ClassName + " " + logLevel + " " + message);
        }
    }
}
