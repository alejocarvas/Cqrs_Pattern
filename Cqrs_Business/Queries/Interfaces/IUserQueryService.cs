using Cqrs_DTO;
using System.Collections.Generic;

namespace Cqrs_Domain.Queries.Interfaces
{
    public interface IUserQueryService
    {
        public IEnumerable<User> Get();

        public User GetById(int id);

        public int UserCount();

        public IEnumerable<UserGroupingByAge> UserGroupingByAges();
    }
}
