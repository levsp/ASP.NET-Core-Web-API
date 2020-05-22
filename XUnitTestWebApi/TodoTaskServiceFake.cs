using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApi.Entities;
using WebApi.Services.Interfaces;

namespace XUnitTestWebApi
{
    public class TodoTaskServiceFake : ITodoTaskService
    {
        private readonly List<TodoTask> _todoTask;

        public TodoTaskServiceFake()
        {
            _todoTask = new List<TodoTask>()
            {
                new TodoTask()
                {
                    TodoTaskId = 1,
                    Name = "Write",
                    DueDate = DateTime.Now.AddDays(3),
                    City = "LA",
                    AssignedTo = "qq@gmail.com",
                    PriorityId = 1,
                    StatusId = 1
                },
                new TodoTask()
                {
                    TodoTaskId = 2,
                    Name = "Read",
                    DueDate = DateTime.Now.AddDays(3),
                    City = "LA",
                    AssignedTo = "qq@gmail.com",
                    PriorityId = 1,
                    StatusId = 1
                },
                new TodoTask()
                {
                    TodoTaskId = 3,
                    Name = "Run",
                    DueDate = DateTime.Now.AddDays(3),
                    City = "LA",
                    AssignedTo = "qq@gmail.com",
                    PriorityId = 1,
                    StatusId = 1
                }
            };
        }

        public void Add(TodoTask entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TodoTask entity)
        {
            var existing = _todoTask.First(a => a.TodoTaskId == entity.TodoTaskId);
            _todoTask.Remove(existing);
        }

        public TodoTask Get(int id)
        {
            return _todoTask.Where(a => a.TodoTaskId == id)
            .FirstOrDefault();
        }

        public IEnumerable<TodoTask> GetAll()
        {
            return _todoTask;
        }

        public IEnumerable<TodoTask> GetByFilters(IEnumerable<Filter> filters)
        {
            throw new NotImplementedException();
        }

        public void Update(TodoTask dbEntity, TodoTask entity)
        {
            throw new NotImplementedException();
        }
    }
}
