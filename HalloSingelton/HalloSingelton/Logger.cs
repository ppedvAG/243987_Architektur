namespace HalloSingelton
{
    internal class Logger
    {
        private static Logger _instance = null;
        public static Logger Instance
        {
            get
            {
                if (_instance == null)
                    lock (typeof(Logger))
                        _instance ??= new Logger();

                return _instance;
            }
        }

        private Logger()
        {
            LogWarn("Logger created");
        }

        public void LogInfo(string message)
        {
            Console.WriteLine($"Info [{DateTime.Now:g}]: {message}");
        }

        public void LogWarn(string message)
        {
            Console.WriteLine($"Warn [{DateTime.Now:g}]: {message}");
        }
    }
}
