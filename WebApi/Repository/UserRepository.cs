using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models;
using WebApi.Repository.Interfaces;

namespace WebApi.Repository
{
    public class UserRepository : IUserRepository<Entities.User>
    {
        readonly DataContext _dataContext;

        public UserRepository(DataContext context)
        {
            _dataContext = context;
        }

        public bool IfExists(Entities.User entity)
        {
            return _dataContext.Users
                .Any(x => x.FirstName == entity.FirstName
                 &&  x.LastName == entity.LastName);
        }

        Entities.User IUserRepository<Entities.User>.Create(Entities.User entity)
        {
            _dataContext.Users.Add(entity);
            _dataContext.SaveChanges();
            return entity;
        }

    }

}
