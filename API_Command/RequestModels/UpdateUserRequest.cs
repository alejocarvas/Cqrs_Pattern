using MediatR;

namespace API_Command.RequestModels
{
    public class UpdateUserRequest : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

    }
}
