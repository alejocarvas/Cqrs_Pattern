using API_Command.RequestModels;
using Cqrs_Domain.Commands.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace API_Command.Handlers
{
    public class UpdateUserNameHandler : IRequestHandler<UpdateUserNameRequest, bool>
    {
        private IUserCommandService _service;

        public UpdateUserNameHandler(IUserCommandService service)
        {
            _service = service;
        }

        public async Task<bool> Handle(UpdateUserNameRequest request, CancellationToken cancellationToken)
        {
            _service.UpdateUserName(request.Id, request.Name);
            return await Task.FromResult(true);
        }
    }
}
