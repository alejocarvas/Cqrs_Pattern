using MediatR;

namespace API_Command.RequestModels
{
    public class CreateMovieUserClickedRequest : IRequest<bool>
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }
    }
}
