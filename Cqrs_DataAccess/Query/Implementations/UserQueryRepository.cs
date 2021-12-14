using Cqrs_DataAccess.Query.Interfaces;
using Cqrs_DTO;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Cqrs_DataAccess.Query.Implementations
{
    public class UserQueryRepository : IUserQueryRepository
    {
        private QueryContext context;
        private DbSet<User> userEntity;


        public UserQueryRepository(QueryContext context)
        {
            this.context = context;
            userEntity = context.Set<User>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> GetAll()
        {
            return userEntity.AsEnumerable();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetById(int id)
        {
            return userEntity.SingleOrDefault(s => s.Id == id);
        }

        /// <summary>
        /// User counter
        /// </summary>
        /// <returns>User number</returns>
        public int UserCount()
        {
            return userEntity.Count();
        }

        public IEnumerable<UserGroupingByAge> UserGroupingByAges()
        {
            return userEntity.GroupBy(u => u.Age).Select(x => new UserGroupingByAge()
            {
                Age = x.Key,
                Count = x.Count()
            });
        }
    }
}
