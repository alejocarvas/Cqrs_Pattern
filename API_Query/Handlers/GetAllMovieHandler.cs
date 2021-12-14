using API_Query.RequestModels;
using API_Query.ResponseModels;
using Cqrs_Domain.Queries.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API_Query.Handlers
{
    public class GetAllMovieHandler : IRequestHandler<GetAllMovieRequest, GetAllMovieResponse>
    {
        private IMovieQueryService _service;

        public GetAllMovieHandler(IMovieQueryService service)
        {
            _service = service;
        }

        public async Task<GetAllMovieResponse> Handle(GetAllMovieRequest request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new GetAllMovieResponse()
            {
                Movies = _service.Get()
            });
        }
    }
}
