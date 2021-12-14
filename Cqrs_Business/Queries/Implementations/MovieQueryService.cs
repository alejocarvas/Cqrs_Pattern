using Cqrs_DataAccess.Query.Interfaces;
using Cqrs_Domain.Queries.Interfaces;
using Cqrs_DTO;
using System.Collections.Generic;

namespace Cqrs_Domain.Queries.Implementations
{
    public class MovieQueryService : IMovieQueryService
    {
        private IMovieQueryRepository _repository;

        public MovieQueryService(IMovieQueryRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Movie> Get()
        {
            return _repository.GetAll();
        }

        public IEnumerable<Movie> GetByGender(string gender)
        {
            return _repository.GetByGender(gender);
        }

        public Movie GetById(int id)
        {
            return _repository.GetById(id);
        }

        public int MovieCount()
        {
            return _repository.MovieCount();
        }

        public IEnumerable<MovieGroupingByGender> MovieGroupingByGenders()
        {
            return _repository.GetMoviesByGender();
        }
    }
}
