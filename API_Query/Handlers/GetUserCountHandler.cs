using API_Query.RequestModels;
using API_Query.ResponseModels;
using Cqrs_Domain.Queries.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API_Query.Handlers
{
    public class GetUserCountHandler : IRequestHandler<GetUserCountRequest, GetUserCountResponse>
    {
        private IUserQueryService _service;

        public GetUserCountHandler(IUserQueryService service)
        {
            _service = service;
        }

        public Task<GetUserCountResponse> Handle(GetUserCountRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new GetUserCountResponse()
            {
                Count = _service.UserCount()
            });
        }
    }
}
