using Cqrs_DataAccess.Command.Interfaces;
using Cqrs_DTO;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Cqrs_DataAccess.Command.Implementations
{
    public class UserCommandRepository : IUserCommandRepository
    {
        private CommandContext context;
        private DbSet<User> userEntity;

        public UserCommandRepository(CommandContext context)
        {
            this.context = context;
            userEntity = context.Set<User>();
        }

        /// <summary>
        /// Delete a user
        /// </summary>
        /// <param name="id">User identifier</param>
        public void Delete(long id)
        {
            User user = GetById(id);
            userEntity.Remove(user);
            context.SaveChanges();
        }

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id">User identifier</param>
        /// <returns>User</returns>
        private User GetById(long id)
        {
            return userEntity.SingleOrDefault(s => s.Id == id);
        }

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="user">User to insert</param>
        /// <returns>User identifier</returns>
        public async Task<int> Save(User user)
        {
            context.Entry(user).State = EntityState.Added;
            context.SaveChanges();
            return await Task.FromResult(user.Id);
        }

        /// <summary>
        /// Update a full user
        /// </summary>
        /// <param name="user">User to update</param>
        public void Update(User user)
        {
            User userEntity = GetById(user.Id);
            userEntity.Name = user.Name;
            userEntity.Age = user.Age;
            context.SaveChanges();
        }

        /// <summary>
        /// Update user name
        /// </summary>
        /// <param name="id">User identifier</param>
        /// <param name="name">User name</param>
        public void UpdateName(int id, string name)
        {
            User userEntity = GetById(id);
            userEntity.Name = name;
            context.SaveChanges();
        }

        /// <summary>
        /// Update user age
        /// </summary>
        /// <param name="id">User identifier</param>
        /// <param name="age">User age</param>
        public void UpdateAge(int id, int age)
        {
            User userEntity = GetById(id);
            userEntity.Age = age;
            context.SaveChanges();
        }
    }
}
