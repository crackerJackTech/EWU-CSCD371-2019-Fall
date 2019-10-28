using System;

namespace Logger
{
    public static class BaseLoggerMixins
    {
        public static void Error(this BaseLogger baseLogger, string logLevel, params object[] message)
        {
            
            if(baseLogger is null)
            {
                throw new ArgumentNullException(nameof(baseLogger));
            }

            baseLogger.Log(LogLevel.Error, string.Format(logLevel, message));

        }

        public static void Warning(this BaseLogger baseLogger, string logLevel, params object[] message)
        {
            if (baseLogger is null)
            {
                throw new ArgumentNullException(nameof(baseLogger));
            }

            baseLogger.Log(LogLevel.Warning, string.Format(logLevel, message));

        }

        public static void Information(this BaseLogger baseLogger, string logLevel, params object[] message)
        {
            if (baseLogger is null)
            {
                throw new ArgumentNullException(nameof(baseLogger));
            }

            baseLogger.Log(LogLevel.Warning, string.Format(logLevel, message));

        }

        public static void Debug(this BaseLogger baseLogger, string logLevel, params object[] message)
        {
            if (baseLogger is null)
            {
                throw new ArgumentNullException(nameof(baseLogger));
            }

            baseLogger.Log(LogLevel.Debug, string.Format(logLevel, message));

        }
    }
}
