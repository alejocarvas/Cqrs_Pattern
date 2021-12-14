using Cqrs_DataAccess.Command.Interfaces;
using Cqrs_DTO;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Cqrs_DataAccess.Command.Implementations
{
    public class MovieCommandRepository : IMovieCommandRepository
    {
        private CommandContext context;
        private DbSet<Movie> movieEntity;

        public MovieCommandRepository(CommandContext context)
        {
            this.context = context;
            movieEntity = context.Set<Movie>();
        }

        public void Delete(long id)
        {
            Movie movie = GetById(id);
            movieEntity.Remove(movie);
            context.SaveChanges();
        }

        public Movie GetById(long id)
        {
            return movieEntity.SingleOrDefault(s => s.Id == id);
        }

        public async Task<int> Save(Movie movie)
        {
            context.Entry(movie).State = EntityState.Added;
            context.SaveChanges();
            return await Task.FromResult(movie.Id);
        }

        public void Save(MovieClick movieclick)
        {
            context.Entry(movieclick).State = EntityState.Added;
            context.SaveChanges();
        }

        public void Update(Movie movie)
        {
            context.SaveChanges();
        }

    }
}
