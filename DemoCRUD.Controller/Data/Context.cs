using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCRUD.Controller.Data
{
    public class Context : IDisposable
    {
        private string _databasePath = $"{AppDomain.CurrentDomain.BaseDirectory}demo-crud.s3db";

        private SQLiteConnection Connection { get; set; }

        public SQLiteCommand Command { get; private set; }

        public Context()
        {
            CreateDatabase();

            Connection = new SQLiteConnection();
            Command = Connection.CreateCommand();
            Command.Connection.ConnectionString = $"Data Source={_databasePath}";
            Command.Connection.Open();

            CreateTable();
        }

        private void CreateDatabase()
        {
            if (!System.IO.File.Exists(_databasePath))
                System.IO.File.Create(_databasePath).Close();
        }

        private void CreateTable()
        {
            string sql = @"CREATE TABLE IF NOT EXISTS Cliente(
							Id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
							Nome NVARCHAR(100) NULL,
							Cpf NVARCHAR(14) NULL,
							DataNascimento DATE NULL,
							DataRegistro DATETIME NULL
						);";

            Command.CommandText = sql;
            Command.ExecuteNonQuery();
        }


        public void DropDatabase()
        {
            if (System.IO.File.Exists(_databasePath))
                System.IO.File.Delete(_databasePath);
        }

        public void Dispose()
        {
            if (Command.Connection.State == System.Data.ConnectionState.Open)
                Command.Connection.Close();
        }
    }
}
