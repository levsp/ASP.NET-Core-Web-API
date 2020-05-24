using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Repository.Interfaces;

namespace WebApi.Services.Interfaces
{
    public interface ITodoTaskService : ITodoTaskRepository<Entities.TodoTask>
    {
        IEnumerable<Entities.TodoTask> GetAll();
        IEnumerable<Entities.TodoTask> GetByFilters(IEnumerable<Filter> filters);
        Entities.TodoTask Get(int id);
        void Add(Entities.TodoTask entity);
        void Update(Entities.TodoTask dbEntity, Entities.TodoTask entity);
        void Delete(Entities.TodoTask entity);
    }
}
