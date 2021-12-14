using Cqrs_DataAccess.Mapper;
using Cqrs_DTO;
using Microsoft.EntityFrameworkCore;

namespace Cqrs_DataAccess.Command
{
    public class CommandContext : DbContext
    {
        public CommandContext(DbContextOptions<CommandContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new UserMap(modelBuilder.Entity<User>());
            new MovieMap(modelBuilder.Entity<Movie>());
            new MovieClickMap(modelBuilder.Entity<MovieClick>());
        }
    }
}
