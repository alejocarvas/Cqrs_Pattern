using Cqrs_DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cqrs_DataAccess.Command.Interfaces
{
    public interface IUserCommandRepository
    {
        User GetById(long id);
        void Save(User user);
        void Update(User user);
        void Delete(long id);
    }
}
