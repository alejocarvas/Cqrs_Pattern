using Cqrs_DTO;
using System.Threading.Tasks;

namespace Cqrs_Domain.Commands.Interfaces
{
    public interface IMovieCommandService
    {
        /// <summary>
        /// Create a new movie
        /// </summary>
        /// <param name="movie">Object User with the information</param>
        /// <returns>Movie identifier</returns>
        public Task<int> CreateMovie(Movie movie);
        /// <summary>
        /// Create a new click in a movie
        /// </summary>
        /// <param name="movieclick">Object MovieClick with the information</param>
        public void CreateMovieClick(MovieClick movieclick);
        /// <summary>
        /// Delete a movie
        /// </summary>
        /// <param name="id">User identifier</param>
        public void DeleteMovie(int id);
        /// <summary>
        /// Update a full movie
        /// </summary>
        /// <param name="movie">Object User with the information</param>
        public void UpdateMovie(Movie movie);
    }
}
