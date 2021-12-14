using Cqrs_DTO;
using System.Collections.Generic;

namespace Cqrs_DataAccess.Query.Interfaces
{
    public interface IMovieQueryRepository
    {
        IEnumerable<Movie> GetAll();
        Movie GetById(int id);
        IEnumerable<Movie> GetByGender(string gender);
        int MovieCount();
        IEnumerable<MovieGroupingByGender> GetMoviesByGender();
    }
}
