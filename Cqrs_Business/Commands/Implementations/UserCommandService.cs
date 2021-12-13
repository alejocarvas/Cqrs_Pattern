using Cqrs_DataAccess.Command.Interfaces;
using Cqrs_Domain.Commands.Interfaces;
using Cqrs_DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cqrs_Domain.Commands.Implementations
{
    public class UserCommandService : IUserCommandService
    {
        private IUserCommandRepository _repository;

        public UserCommandService(IUserCommandRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="user">Object User with the information</param>
        /// <returns></returns>
        public async Task<int> CreateUser(User user)
        {
            return await _repository.Save(user);
        }

        /// <summary>
        /// Delete a user by id
        /// </summary>
        /// <param name="id">User identifier</param>
        public void DeleteUser(int id)
        {
            _repository.Delete(id);
        }

        /// <summary>
        /// Update a new user
        /// </summary>
        /// <param name="user">Object User with the information</param>
        public void UpdateUser(User user)
        {
            _repository.Update(user);
        }

        /// <summary>
        /// Update user age
        /// </summary>
        /// <param name="id">User identifier</param>
        /// <param name="age">User age</param>
        public void UpdateUserAge(int id, int age)
        {
            _repository.UpdateAge(id, age);
        }

        /// <summary>
        /// Update user name
        /// </summary>
        /// <param name="id">User identifier</param>
        /// <param name="name">User name</param>
        public void UpdateUserName(int id, string name)
        {
            _repository.UpdateName(id, name);
        }
    }
}
