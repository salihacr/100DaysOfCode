using System;

namespace DesignPatterns.Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            Creater creater = new Creater(new SqlDatabase());
            Console.WriteLine("---------------------------");
            creater = new Creater(new MySqlDatabase());

            Console.ReadKey();
        }
    }
    abstract class Connection
    {
        public abstract bool Connect();
        public abstract bool DisConnect();
        public abstract string State { get; }
    }
    abstract class Command
    {
        public abstract void Execute(string query);
    }
    class SqlConnection : Connection
    {
        public override string State => "Open";
        public override bool Connect()
        {
            Console.WriteLine("Sql Connection Bağlantısı kuruluyor...");
            return true;
        }

        public override bool DisConnect()
        {
            Console.WriteLine("Sql Connection Bağlantısı kapatılıyor...");
            return false;
        }
    }
    class SqlCommand : Command
    {
        public override void Execute(string query) => Console.WriteLine("SqlCommand sorgusu çalıştırıldı.");
    }


    class MySqlConnection : Connection
    {
        public override string State => "Open";
        public override bool Connect()
        {
            Console.WriteLine("MySql Connection Bağlantısı kuruluyor...");
            return true;
        }

        public override bool DisConnect()
        {
            Console.WriteLine("MySql Connection Bağlantısı kapatılıyor...");
            return false;
        }
    }
    class MySqlCommand : Command
    {
        public override void Execute(string query) => Console.WriteLine("MySqlCommand sorgusu çalıştırıldı.");
    }
    // Abstract Factory
    abstract class DatabaseFactory
    {
        public abstract Connection CreateConnection();
        public abstract Command CreateCommand();
    }
    // Concrete Factory
    class SqlDatabase : DatabaseFactory
    {
        public override Command CreateCommand() => new SqlCommand();

        public override Connection CreateConnection() => new SqlConnection();
    }
    class MySqlDatabase : DatabaseFactory
    {
        public override Command CreateCommand() => new MySqlCommand();

        public override Connection CreateConnection() => new MySqlConnection();
    }

    // Creater class
    class Creater
    {
        DatabaseFactory _databaseFactory;
        Connection _connection;
        Command _command;
        public Creater(DatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
            _connection = _databaseFactory.CreateConnection();
            _command = _databaseFactory.CreateCommand();

            Start();
        }
        void Start()
        {
            if (_connection.State == "Open")
            {
                _connection.Connect();
                _command.Execute("Select * From ...");
                _connection.DisConnect();
            }
        }
    }
}
