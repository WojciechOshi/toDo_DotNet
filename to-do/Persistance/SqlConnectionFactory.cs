using Microsoft.Data.Sqlite;
using System.Data;

namespace to_do.Persistance
{
    public class SQLiteConnectionFactory : ISQLiteConnectionFactory
    {
        private readonly string connectionString;

        public SQLiteConnectionFactory()
        {
            connectionString = $"Data Source=Database/database.db";
        }

        public IDbConnection CreateConnection()
        {
            return new SqliteConnection(connectionString);
        }
    }
}
