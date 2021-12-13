using MediatR;

namespace API_Command.RequestModels
{
    public class UpdateUserAgeRequest : IRequest<bool>
    {
        public int Id { get; set; }
        public int Age { get; set; }
    }
}
