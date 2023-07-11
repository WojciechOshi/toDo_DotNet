using to_do.Models;

namespace to_do
{
    public interface IDBMock
    {
        List<ToDoItem> GetData();

        List<ToDoItem> AddData(ToDoItem item);
    }
}