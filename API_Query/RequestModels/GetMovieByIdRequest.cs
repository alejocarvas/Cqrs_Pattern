using API_Query.ResponseModels;
using MediatR;

namespace API_Query.RequestModels
{
    public class GetMovieByIdRequest : IRequest<GetMovieByIdResponse>
    {
        public int Id { get; set; }
    }
}
