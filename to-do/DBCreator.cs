using Dapper;
using to_do.Persistance;
using to_do;
using Microsoft.Data.Sqlite;

namespace ToDo
{
    public class DbCreator : IDBCreator
    {
        private readonly ISQLiteConnectionFactory _sqliteConnectionFactory;

        public DbCreator(ISQLiteConnectionFactory sqliteConnectionFactory)
        {
            _sqliteConnectionFactory = sqliteConnectionFactory;
        }

        public void CreateDatabase()
        {
            using (var connection = _sqliteConnectionFactory.CreateConnection())
            {
                connection.Open();

                // Create the table if it doesn't exist
                connection.Execute(@"CREATE TABLE IF NOT EXISTS ToDoList (
                                Name TEXT NOT NULL,
                                CashValue DOUBLE NOT NULL,
                                Description TEXT NOT NULL,
                                Date DATETIME NOT NULL
                            )");
            }
        }
    }
}