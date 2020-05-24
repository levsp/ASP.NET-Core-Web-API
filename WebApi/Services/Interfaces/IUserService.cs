using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Repository.Interfaces;
using WebApi.Repository;
using WebApi.Entities;

namespace WebApi.Services.Interfaces
{
    public interface IUserService : IUserRepository<Entities.User>
    {
        public User Create(Entities.User user, string password);
    }
}
