using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Repository;
using WebApi.Repository.Interfaces;
using WebApi.Services.Interfaces;

namespace WebApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository<User> _userRepository;

        public UserService(IUserRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public User Create(User user, string password)
        {
            if (IfExists(user))
                throw new Exception("\"" + user.FirstName + user.LastName + "\" is already taken");

            var createdUser = _userRepository.Create(user);
            return createdUser;
        }

        public User Create(User entity)
        {
            throw new NotImplementedException();
        }

        public bool IfExists(User entity)
        {
            return _userRepository.IfExists(entity);
        }
    }
}
