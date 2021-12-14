using API_Query.RequestModels;
using API_Query.ResponseModels;
using Cqrs_Domain.Queries.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API_Query.Handlers
{
    public class GetMoviesByGenderHandler : IRequestHandler<GetMoviesByGenderRequest, GetMoviesByGenderResponse>
    {
        private IMovieQueryService _service;

        public GetMoviesByGenderHandler(IMovieQueryService service)
        {
            _service = service;
        }

        public async Task<GetMoviesByGenderResponse> Handle(GetMoviesByGenderRequest request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new GetMoviesByGenderResponse()
            {
                Movies  = _service.GetByGender(request.Gender)
            });
        }
    }
}
