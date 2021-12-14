using Cqrs_DTO;
using System.Collections.Generic;

namespace Cqrs_DataAccess.Query.Interfaces
{
    public interface IUserQueryRepository
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        int UserCount();
        IEnumerable<UserGroupingByAge> UserGroupingByAges();
    }
}
