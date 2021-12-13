using API_Command.RequestModels;
using Cqrs_Domain.Commands.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace API_Command.Handlers
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserRequest, bool>
    {
        private IUserCommandService _service;

        public DeleteUserHandler(IUserCommandService service)
        {
            _service = service;
        }

        public async Task<bool> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            _service.DeleteUser(request.Id);
            return await Task.FromResult(true);
        }
    }
}
