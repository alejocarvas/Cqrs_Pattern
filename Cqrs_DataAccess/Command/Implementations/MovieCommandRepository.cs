using Cqrs_DataAccess.Command.Interfaces;
using Cqrs_DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public void Save(Movie movie)
        {
            context.Entry(movie).State = EntityState.Added;
            context.SaveChanges();
        }

        public void Update(Movie movie)
        {
            context.SaveChanges();
        }
    }
}
