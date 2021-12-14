using Cqrs_DataAccess.Command.Interfaces;
using Cqrs_Domain.Commands.Interfaces;
using Cqrs_DTO;
using System.Threading.Tasks;

namespace Cqrs_Domain.Commands.Implementations
{
    public class MovieCommandService : IMovieCommandService
    {
        private IMovieCommandRepository _repository;

        public MovieCommandService(IMovieCommandRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> CreateMovie(Movie movie)
        {
            return await _repository.Save(movie);
        }

        public void CreateMovieClick(MovieClick movieclick)
        {
            _repository.Save(movieclick);
        }

        public void DeleteMovie(int id)
        {
            _repository.Delete(id);
        }

        public void UpdateMovie(Movie movie)
        {
            _repository.Update(movie);
        }
    }
}
