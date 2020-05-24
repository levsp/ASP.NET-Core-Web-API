using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;

namespace WebApi.Repository.Interfaces
{
    public interface IUserRepository<TEntity>
    {
        bool IfExists(TEntity entity);
        TEntity Create(TEntity entity);

    }
}
