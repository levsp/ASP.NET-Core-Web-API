using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Repository.Interfaces;

namespace WebApi.Repository
{
    public class TodoTaskRepository : ITodoTaskRepository<TodoTask>
    {
        readonly DataContext _dataContext;

        public TodoTaskRepository(DataContext context)
        {
            _dataContext = context;
        }

        void ITodoTaskRepository<TodoTask>.Add(TodoTask entity)
        {
            _dataContext.TodoTasks.Add(entity);
            _dataContext.SaveChanges();
        }

        void ITodoTaskRepository<TodoTask>.Delete(TodoTask entity)
        {
            _dataContext.TodoTasks.Remove(entity);
            _dataContext.SaveChanges();
        }

        IEnumerable<TodoTask> ITodoTaskRepository<TodoTask>.GetByFilters(IEnumerable<Filter> filters)
        {
            var todo = _dataContext.TodoTasks.AsQueryable().Include("Priority").Include("Status");
            var res = CommonHelper.GetQueryableList(filters, todo);

            return res;
        }

        IEnumerable<TodoTask> ITodoTaskRepository<TodoTask>.GetAll()
        {
            return _dataContext.TodoTasks.Include("Priority").Include("Status");
        }

        void ITodoTaskRepository<TodoTask>.Update(TodoTask dbEntity, TodoTask entity)
        {
            dbEntity.Name = entity.Name;
            dbEntity.DueDate = entity.DueDate;
            dbEntity.City = entity.City;
            dbEntity.AssignedTo = entity.AssignedTo;
            dbEntity.PriorityId = entity.PriorityId;
            dbEntity.StatusId = entity.StatusId;

            _dataContext.SaveChanges();
        }

        TodoTask ITodoTaskRepository<TodoTask>.Get(int id)
        {
            return _dataContext.TodoTasks.FirstOrDefault(e => e.TodoTaskId == id);
        }
    }
}
