using System;

namespace Logger
{
    public static class BaseLoggerMixins
    {
        public static void Error(this BaseLogger baseLogger, string logLevel, params object[] message)
        {
            
            if(baseLogger is null)
            {
                throw new ArgumentNullException();
            }

            LogLevel log = LogLevel.Error;

            foreach(object obs in message)
            {
                baseLogger.Log(log, obs.ToString());
            }



            

        }

        public static void Warning(this BaseLogger baseLogger, string logLevel, params object[] message)
        {
            if (baseLogger is null)
            {
                throw new ArgumentNullException();
            }

            LogLevel log = LogLevel.Warning;

            foreach (object obs in message)
            {
                baseLogger.Log(log, obs.ToString());
            }

            return;

        }

        public static void Information(this BaseLogger baseLogger, string logLevel, params object[] message)
        {
            if (baseLogger is null)
            {
                throw new ArgumentNullException();
            }

            LogLevel log = LogLevel.Information;

            foreach (object obs in message)
            {
                baseLogger.Log(log, obs.ToString());
            }

            return;

        }

        public static void Debug(this BaseLogger baseLogger, string logLevel, params object[] message)
        {
            if (baseLogger is null)
            {
                throw new ArgumentNullException();
            }

            LogLevel log = LogLevel.Debug;

            foreach (object obs in message)
            {
                baseLogger.Log(log, obs.ToString());
            }

            return;

        }
    }
}
