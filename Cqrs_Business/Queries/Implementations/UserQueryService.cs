using Cqrs_DataAccess.Query.Interfaces;
using Cqrs_Domain.Queries.Interfaces;
using Cqrs_DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cqrs_Domain.Queries.Implementations
{
    public class UserQueryService : IUserQueryService
    {
        private IUserQueryRepository _repository;

        public UserQueryService(IUserQueryRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<User> Get()
        {
            return _repository.GetAll();
        }

        public User GetById(int id)
        {
            return _repository.GetById(id);
        }

        public int UserCount()
        {
            return _repository.UserCount();
        }

        public IEnumerable<UserGroupingByAge> UserGroupingByAges()
        {
            return _repository.UserGroupingByAges();
        }
    }
}
