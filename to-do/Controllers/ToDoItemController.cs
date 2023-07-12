using Dapper;
using Microsoft.AspNetCore.Mvc;
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
            DbMock.AddData(item);
            return new JsonResult(DbMock.GetData());
        }
    }
}