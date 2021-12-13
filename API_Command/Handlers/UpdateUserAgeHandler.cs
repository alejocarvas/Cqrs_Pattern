using API_Command.RequestModels;
using Cqrs_Domain.Commands.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API_Command.Handlers
{
    public class UpdateUserAgeHandler : IRequestHandler<UpdateUserAgeRequest, bool>
    {
        private IUserCommandService _service;

        public UpdateUserAgeHandler(IUserCommandService service)
        {
            _service = service;
        }

        public async Task<bool> Handle(UpdateUserAgeRequest request, CancellationToken cancellationToken)
        {
            _service.UpdateUserAge(request.Id, request.Age);
            return await Task.FromResult(true);
        }
    }
}
