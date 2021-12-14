using API_Command.RequestModels;
using Cqrs_Domain.Commands.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace API_Command.Handlers
{
    public class CreateMovieUserClickedHandler : IRequestHandler<CreateMovieUserClickedRequest, bool>
    {
        private IMovieCommandService _service;

        public CreateMovieUserClickedHandler(IMovieCommandService service)
        {
            _service = service;
        }

        public Task<bool> Handle(CreateMovieUserClickedRequest request, CancellationToken cancellationToken)
        {
            _service.CreateMovieClick(new Cqrs_DTO.MovieClick()
            {
                IdUser = request.UserId,
                IdMovie = request.MovieId,
                DateClick = DateTime.Now

            });
            return Task.FromResult(true);
        }
    }
}
