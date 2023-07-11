using System;
using to_do.Models;

namespace to_do
{
    public class DbMock : IDBMock
    {
        private List<ToDoItem> data;

        public DbMock()
        {
            data = Enumerable.Range(1, 5).Select(index => new ToDoItem
            {
                Name = "Dagmara",
                Description = "Kupiła loda",
                CashValue = 69,
                Date = DateTime.Now.AddDays(index),
            })
            .ToList();
        }

        public List<ToDoItem> GetData()
        {
            return data;
        }

        public List<ToDoItem> AddData(ToDoItem item)
        {
            data.Add(item);
            return data;
        }
    }
}