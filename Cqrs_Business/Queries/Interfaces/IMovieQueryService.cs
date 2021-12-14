using Cqrs_DTO;
using System.Collections.Generic;

namespace Cqrs_Domain.Queries.Interfaces
{
    public interface IMovieQueryService
    {
        public IEnumerable<Movie> Get();

        public Movie GetById(int id);
        public IEnumerable<Movie> GetByGender(string gender);
        public int MovieCount();
        public IEnumerable<MovieGroupingByGender> MovieGroupingByGenders();
    }
}
