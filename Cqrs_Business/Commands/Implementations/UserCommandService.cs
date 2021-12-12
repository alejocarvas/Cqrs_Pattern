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
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <returns></returns>
        public Task<int> CreateUser(string name, int age)
        {
            _repository.Save(new User()
            {
                Name = name,
                Age = age
            });
            return Task.FromResult(0);
        }
    }
}
