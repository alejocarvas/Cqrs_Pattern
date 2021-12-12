using Cqrs_DataAccess.Command.Interfaces;
using Cqrs_DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public void Delete(long id)
        {
            User user = GetById(id);
            userEntity.Remove(user);
            context.SaveChanges();
        }

        public User GetById(long id)
        {
            return userEntity.SingleOrDefault(s => s.Id == id);
        }

        public void Save(User user)
        {
            context.Entry(user).State = EntityState.Added;
            context.SaveChanges();
        }

        public void Update(User user)
        {
            context.SaveChanges();
        }
    }
}
