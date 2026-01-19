using System;

namespace DesignPattern.Singleton
{
    
    public sealed class Logger
    {
        private static readonly Lazy<Logger> _instance = new Lazy<Logger>(() => new Logger());
        private readonly List<string> _logs = new List<string>();

        private Logger() { }

        public static Logger Instance => _instance.Value;

        public void Log(string message)
        {
            string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";
            _logs.Add(logEntry);
            Console.WriteLine(logEntry);
        }

        public void ShowAllLogs()
        {
            Console.WriteLine("\n=== All Logs ===");
            foreach (var log in _logs)
            {
                Console.WriteLine(log);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("2. Logger Singleton:");
            var logger1 = Logger.Instance;
            var logger2 = Logger.Instance;
            
            Console.WriteLine($"Are both logger instances the same? {ReferenceEquals(logger1, logger2)}");
            
            logger1.Log("Application started");
            logger2.Log("User logged in");
            logger1.Log("Processing data...");
            
            Console.WriteLine("\nShowing all logs:");
            logger1.ShowAllLogs();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
