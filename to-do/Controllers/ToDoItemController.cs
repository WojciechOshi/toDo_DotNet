using Microsoft.AspNetCore.Mvc;
using to_do.Models;

namespace to_do.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoItemController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<ToDoItem> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new ToDoItem
            {
                Name = "Dagulka",
                Description = "Kupila cwela w ciescie",
                CashValue = 420,
                Date = DateTime.Now.AddDays(index),
            })
            .ToArray();
        }
    }
}