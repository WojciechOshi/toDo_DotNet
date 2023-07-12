using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using to_do.Models;
using to_do.Persistance;

namespace to_do.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoItemController : ControllerBase
    {
        private readonly ISQLiteConnectionFactory _sqliteConnectionFactory;

        public ToDoItemController(IDBMock dbMock, ISQLiteConnectionFactory sqLiteConnectionFactory)
        {
            DbMock = dbMock;
            _sqliteConnectionFactory = sqLiteConnectionFactory;
        }

        public IDBMock DbMock { get; }

        [HttpGet]
        public IEnumerable<ToDoItem> Get()
        {
            var connection = _sqliteConnectionFactory.CreateConnection();

            var toDoItems = connection.Query<ToDoItem>("SELECT * FROM ToDoList");

            return toDoItems;
        }

        [HttpPost]
        public IActionResult Post(ToDoItem item)
        {
            var connection = _sqliteConnectionFactory.CreateConnection();

            connection.Open();

            // Prepare the INSERT statement
            var insertSql = @"INSERT INTO ToDoList (Name, CashValue, Description, Date)
                      VALUES (@Name, @CashValue, @Description, @Date)";

            // Create a command object
            using (var command = new SqliteCommand(insertSql, (SqliteConnection?)connection))
            {
                // Add parameters and set their values
                command.Parameters.AddWithValue("@Name", item.Name);
                command.Parameters.AddWithValue("@CashValue", item.CashValue);
                command.Parameters.AddWithValue("@Description", item.Description);
                command.Parameters.AddWithValue("@Date", item.Date);

                // Execute the INSERT statement
                command.ExecuteNonQuery();
            }

            var toDoItems = connection.Query<ToDoItem>("SELECT * FROM ToDoList");

            return new JsonResult(toDoItems);
        }
    }
}