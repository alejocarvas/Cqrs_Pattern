using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cqrs_Domain.Commands.Interfaces
{
    public interface IUserCommandService
    {
        public Task<int> CreateUser(string name, int age);
    }
}
