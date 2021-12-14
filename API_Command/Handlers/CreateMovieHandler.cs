using API_Command.RequestModels;
using API_Command.ResponseModels;
using Cqrs_Domain.Commands.Interfaces;
using Cqrs_DTO;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API_Command.Handlers
{
    public class CreateMovieHandler : IRequestHandler<CreateMovieRequest, CreateMovieResponse>
    {
        private IMovieCommandService _service;

        public CreateMovieHandler(IMovieCommandService service)
        {
            _service = service;
        }

        public async Task<CreateMovieResponse> Handle(CreateMovieRequest request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new CreateMovieResponse()
            {
                Id = _service.CreateMovie(new Movie()
                {
                    Title = request.Title,
                    Director = request.Director,
                    Distributor = request.Distributor,
                    MajorGenre = request.MajorGenre,
                    Rating = request.Rating,
                    ReleaseDate = request.ReleaseDate,
                    Votes = request.Votes
                }).Result
            });
        }
    }
}
