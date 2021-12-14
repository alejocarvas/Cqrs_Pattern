using API_Query.RequestModels;
using API_Query.ResponseModels;
using Cqrs_Domain.Queries.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API_Query.Handlers
{
    public class GetMovieByIdHandler : IRequestHandler<GetMovieByIdRequest, GetMovieByIdResponse>
    {
        private IMovieQueryService _service;

        public GetMovieByIdHandler(IMovieQueryService service)
        {
            _service = service;
        }

        public async Task<GetMovieByIdResponse> Handle(GetMovieByIdRequest request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new GetMovieByIdResponse()
            {
                Movie = _service.GetById(request.Id)
            });
        }
    }
}
