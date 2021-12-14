using API_Query.RequestModels;
using API_Query.ResponseModels;
using Cqrs_Domain.Queries.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API_Query.Handlers
{
    public class GetMovieCountHandler : IRequestHandler<GetMovieCountRequest, GetMovieCountResponse>
    {
        private IMovieQueryService _service;

        public GetMovieCountHandler(IMovieQueryService service)
        {
            _service = service;
        }

        public Task<GetMovieCountResponse> Handle(GetMovieCountRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new GetMovieCountResponse()
            {
                Count = _service.MovieCount()
            });
        }
    }
}
