using MediatR;

namespace API_Command.RequestModels
{
    public class UpdateUserNameRequest : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
