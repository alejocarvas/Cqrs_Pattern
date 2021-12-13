using MediatR;

namespace API_Command.RequestModels
{
    public class DeleteUserRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
