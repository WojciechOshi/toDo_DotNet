using Microsoft.AspNetCore.Mvc;
using to_do.Models;

namespace to_do.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoItemController : ControllerBase
    {
        public ToDoItemController(IDBMock dbMock)
        {
            DbMock = dbMock;
        }

        public IDBMock DbMock { get; }

        [HttpGet]
        public IEnumerable<ToDoItem> Get()
        {
            return DbMock.GetData();
        }

        [HttpPost]
        public IActionResult Post(ToDoItem item)
        {
            DbMock.AddData(item);
            return Ok("Item created successfully.");
        }
    }
}