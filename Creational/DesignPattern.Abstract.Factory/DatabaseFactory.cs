using System;

namespace DesignPattern.Abstract.Factory
{
    public interface IConnection
    {
        void Connect();
        void Disconnect();
    }

    public interface ICommand
    {
        void Execute(string query);
    }

    public interface ITransaction
    {
        void Begin();
        void Commit();
        void Rollback();
    }

    // SQL Server implementations
    public class SqlConnection : IConnection
    {
        public void Connect()
        {
            Console.WriteLine("Connected to SQL Server");
        }

        public void Disconnect()
        {
            Console.WriteLine("Disconnected from SQL Server");
        }
    }

    public class SqlCommand : ICommand
    {
        public void Execute(string query)
        {
            Console.WriteLine($"Executing SQL Server query: {query}");
        }
    }

    public class SqlTransaction : ITransaction
    {
        public void Begin()
        {
            Console.WriteLine("Beginning SQL Server transaction");
        }

        public void Commit()
        {
            Console.WriteLine("Committing SQL Server transaction");
        }

        public void Rollback()
        {
            Console.WriteLine("Rolling back SQL Server transaction");
        }
    }

    // Oracle implementations
    public class OracleConnection : IConnection
    {
        public void Connect()
        {
            Console.WriteLine("Connected to Oracle Database");
        }

        public void Disconnect()
        {
            Console.WriteLine("Disconnected from Oracle Database");
        }
    }

    public class OracleCommand : ICommand
    {
        public void Execute(string query)
        {
            Console.WriteLine($"Executing Oracle query: {query}");
        }
    }

    public class OracleTransaction : ITransaction
    {
        public void Begin()
        {
            Console.WriteLine("Beginning Oracle transaction");
        }

        public void Commit()
        {
            Console.WriteLine("Committing Oracle transaction");
        }

        public void Rollback()
        {
            Console.WriteLine("Rolling back Oracle transaction");
        }
    }

    public interface IDatabaseFactory
    {
        IConnection CreateConnection();
        ICommand CreateCommand();
        ITransaction CreateTransaction();
    }

    public class SqlServerFactory : IDatabaseFactory
    {
        public IConnection CreateConnection()
        {
            return new SqlConnection();
        }

        public ICommand CreateCommand()
        {
            return new SqlCommand();
        }

        public ITransaction CreateTransaction()
        {
            return new SqlTransaction();
        }
    }

    public class OracleFactory : IDatabaseFactory
    {
        public IConnection CreateConnection()
        {
            return new OracleConnection();
        }

        public ICommand CreateCommand()
        {
            return new OracleCommand();
        }

        public ITransaction CreateTransaction()
        {
            return new OracleTransaction();
        }
    }

    public class DatabaseManager
    {
        private readonly IDatabaseFactory _dbFactory;
        private IConnection _connection;
        private ICommand _command;
        private ITransaction _transaction;

        public DatabaseManager(IDatabaseFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public void Initialize()
        {
            _connection = _dbFactory.CreateConnection();
            _command = _dbFactory.CreateCommand();
            _transaction = _dbFactory.CreateTransaction();
        }

        public void PerformDatabaseOperations()
        {
            _connection.Connect();
            _transaction.Begin();
            _command.Execute("SELECT * FROM Users");
            _transaction.Commit();
            _connection.Disconnect();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sqlManager = new DatabaseManager(new SqlServerFactory());
            sqlManager.Initialize();
            sqlManager.PerformDatabaseOperations();
            
            var oracleManager = new DatabaseManager(new OracleFactory());
            oracleManager.Initialize();
            oracleManager.PerformDatabaseOperations();
            
        }
    }
}
