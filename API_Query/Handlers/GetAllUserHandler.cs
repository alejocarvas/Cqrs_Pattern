using API_Query.RequestModels;
using API_Query.ResponseModels;
using Cqrs_Domain.Queries.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API_Query.Handlers
{
    public class GetAllUserHandler : IRequestHandler<GetAllUserRequest, GetAllUserResponse>
    {
        private IUserQueryService _service;

        public GetAllUserHandler(IUserQueryService service)
        {
            _service = service;
        }

        public Task<GetAllUserResponse> Handle(GetAllUserRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new GetAllUserResponse()
            {
                Users = _service.Get()
            });
        }
    }
}
