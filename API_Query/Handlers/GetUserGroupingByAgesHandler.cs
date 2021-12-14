using API_Query.RequestModels;
using API_Query.ResponseModels;
using Cqrs_Domain.Queries.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace API_Query.Handlers
{
    public class GetUserGroupingByAgesHandler : IRequestHandler<GetUserGroupingByAgesRequest, GetUserGroupingByAgesResponse>
    {
        private IUserQueryService _service;

        public GetUserGroupingByAgesHandler(IUserQueryService service)
        {
            _service = service;
        }

        public Task<GetUserGroupingByAgesResponse> Handle(GetUserGroupingByAgesRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new GetUserGroupingByAgesResponse()
            {
                UserGroupingByAges = _service.UserGroupingByAges()
            });
        }
    }
}
