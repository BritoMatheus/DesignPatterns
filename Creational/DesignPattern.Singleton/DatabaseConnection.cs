using System;

namespace DesignPattern.Singleton
{
    public sealed class DatabaseConnection
    {
        private static readonly Lazy<DatabaseConnection> _instance = new Lazy<DatabaseConnection>(() => new DatabaseConnection());
        private static readonly object _lock = new object();
        private string _connectionString;
        private bool _isConnected;

        // Private constructor to prevent instantiation
        private DatabaseConnection()
        {
            _connectionString = "Server=localhost;Database=MyDB;Trusted_Connection=true;";
            _isConnected = false;
        }

        // Public static property to get the instance
        public static DatabaseConnection Instance => _instance.Value;

        public void Connect()
        {
            lock (_lock)
            {
                if (!_isConnected)
                {
                    Console.WriteLine($"Connecting to database: {_connectionString}");
                    _isConnected = true;
                    Console.WriteLine("Database connected successfully!");
                }
                else
                {
                    Console.WriteLine("Database is already connected.");
                }
            }
        }

        public void Disconnect()
        {
            lock (_lock)
            {
                if (_isConnected)
                {
                    Console.WriteLine("Disconnecting from database...");
                    _isConnected = false;
                    Console.WriteLine("Database disconnected.");
                }
                else
                {
                    Console.WriteLine("Database is not connected.");
                }
            }
        }

        public void ExecuteQuery(string query)
        {
            if (_isConnected)
            {
                Console.WriteLine($"Executing query: {query}");
            }
            else
            {
                Console.WriteLine("Cannot execute query - database not connected.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Database Connection Singleton
            Console.WriteLine("1. Database Connection Singleton:");
            var db1 = DatabaseConnection.Instance;
            var db2 = DatabaseConnection.Instance;
            
            Console.WriteLine($"Are both instances the same? {ReferenceEquals(db1, db2)}");
            
            db1.Connect();
            db2.ExecuteQuery("SELECT * FROM Users");
            db1.Disconnect();

        }
    }
}
