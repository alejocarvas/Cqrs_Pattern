using Cqrs_DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cqrs_Domain.Commands.Interfaces
{
    public interface IUserCommandService
    {
        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="user">Object User with the information</param>
        /// <returns></returns>
        public Task<int> CreateUser(User user);
        /// <summary>
        /// Delete a user
        /// </summary>
        /// <param name="id">User identifier</param>
        public void DeleteUser(int id);
        /// <summary>
        /// Update a full user
        /// </summary>
        /// <param name="user">Object User with the information</param>
        public void UpdateUser(User user);
        /// <summary>
        /// Update user name
        /// </summary>
        /// <param name="id">User identifier</param>
        /// <param name="name">User name</param>
        public void UpdateUserName(int id, string name);
        /// <summary>
        /// Update user age
        /// </summary>
        /// <param name="id">User identifier</param>
        /// <param name="age">User age</param>
        public void UpdateUserAge(int id, int age);
    }
}
