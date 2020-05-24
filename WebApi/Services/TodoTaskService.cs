using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Repository.Interfaces;
using WebApi.Services.Interfaces;

namespace WebApi.Services
{
    public class TodoTaskService : ITodoTaskService
    {
        private readonly ITodoTaskRepository<TodoTask> _todoTaskRepository;

        public TodoTaskService(ITodoTaskRepository<TodoTask> todoTaskRepository)
        {
            _todoTaskRepository = todoTaskRepository;
        }

        public void Add(TodoTask entity)
        {
            _todoTaskRepository.Add(entity);
        }

        public void Delete(TodoTask entity)
        {
            _todoTaskRepository.Delete(entity);
        }

        public IEnumerable<TodoTask> GetAll()
        {
            return _todoTaskRepository.GetAll();
        }

        public IEnumerable<TodoTask> GetByFilters(IEnumerable<Filter> filters)
        {
            return _todoTaskRepository.GetByFilters(filters);
        }

        public void Update(TodoTask dbEntity, TodoTask entity)
        {
            _todoTaskRepository.Update(dbEntity, entity);
        }

        public TodoTask Get(int id)
        {
            return _todoTaskRepository.Get(id);
        }
    }
}
