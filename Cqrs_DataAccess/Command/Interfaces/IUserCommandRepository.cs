using Cqrs_DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cqrs_DataAccess.Command.Interfaces
{
    public interface IUserCommandRepository
    {
        Task<int> Save(User user);
        void Update(User user);
        void UpdateName(int id, string name);
        void UpdateAge(int id, int age);
        void Delete(long id);
    }
}
