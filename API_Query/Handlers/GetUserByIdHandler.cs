using API_Query.RequestModels;
using API_Query.ResponseModels;
using Cqrs_Domain.Queries.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API_Query.Handlers
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdRequest, GetUserByIdResponse>
    {
        private IUserQueryService _service;

        public GetUserByIdHandler(IUserQueryService service)
        {
            _service = service;
        }


        public Task<GetUserByIdResponse> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new GetUserByIdResponse()
            {
                User = _service.GetById(request.Id)
            });
        }
    }
}
