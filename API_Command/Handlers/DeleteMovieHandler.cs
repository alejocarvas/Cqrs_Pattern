using API_Command.RequestModels;
using Cqrs_Domain.Commands.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API_Command.Handlers
{
    public class DeleteMovieHandler : IRequestHandler<DeleteMovieRequest, bool>
    {
        private IMovieCommandService _service;

        public DeleteMovieHandler(IMovieCommandService service)
        {
            _service = service;
        }

        public async Task<bool> Handle(DeleteMovieRequest request, CancellationToken cancellationToken)
        {
            _service.DeleteMovie(request.Id);
            return await Task.FromResult(true);
        }
    }
}
