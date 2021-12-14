using Cqrs_DataAccess.Mapper;
using Cqrs_DTO;
using Microsoft.EntityFrameworkCore;

namespace Cqrs_DataAccess.Query
{
    public class QueryContext : DbContext
    {
        public QueryContext(DbContextOptions<QueryContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new UserMap(modelBuilder.Entity<User>());
            new MovieMap(modelBuilder.Entity<Movie>());
        }
    }
}
