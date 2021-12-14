using Cqrs_DataAccess.Query.Interfaces;
using Cqrs_DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cqrs_DataAccess.Query.Implementations
{
    public class MovieQueryRepository : IMovieQueryRepository
    {
        private QueryContext context;
        private DbSet<Movie> movieEntity;


        public MovieQueryRepository(QueryContext context)
        {
            this.context = context;
            movieEntity = context.Set<Movie>();
        }

        public IEnumerable<Movie> GetAll()
        {
            return movieEntity.AsEnumerable();
        }

        public IEnumerable<Movie> GetByGender(string gender)
        {
            return movieEntity.Where(x => x.MajorGenre == gender);
        }

        public Movie GetById(int id)
        {
            return movieEntity.SingleOrDefault(s => s.Id == id);
        }

        public IEnumerable<MovieGroupingByGender> GetMoviesByGender()
        {
            return movieEntity.GroupBy(m => m.MajorGenre).Select(x => new MovieGroupingByGender()
            {
                Gender = x.Key,
                Count = x.Count()
            });
        }

        public int MovieCount()
        {
            return movieEntity.Count();
        }
    }
}
