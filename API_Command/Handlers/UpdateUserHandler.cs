using API_Command.RequestModels;
using Cqrs_Domain.Commands.Interfaces;
using Cqrs_DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API_Command.Handlers
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, bool>
    {
        private IUserCommandService _service;

        public UpdateUserHandler(IUserCommandService service)
        {
            _service = service;
        }

        public async Task<bool> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            _service.UpdateUser(new User()
            {
               Id = request.Id,
               Name = request.Name,
               Age = request.Age
            });
            return await Task.FromResult(true);
        }
    }
}
