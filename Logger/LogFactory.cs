namespace Logger
{
    public class LogFactory
    {
        private string FilePath;
        public BaseLogger CreateLogger(string className)
        {
            FileLogger fileLogger = new FileLogger
            {
                ClassName = className,
            };
            ConfigureFileLogger(null);
            return fileLogger;
        }

        public void ConfigureFileLogger(string filePath)
        {
            FilePath = filePath;
        }
    }
}
