using API_Command.RequestModels;
using API_Command.ResponseModels;
using Cqrs_Domain.Commands.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API_Command.Handlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        private IUserCommandService _service;

        public CreateUserHandler(IUserCommandService service)
        {
            _service = service;
        }

        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new CreateUserResponse() {
               Id = _service.CreateUser(request.Name, request.Age).Result
            });
        }
    }
}
