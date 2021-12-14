using API_Query.ResponseModels;
using MediatR;

namespace API_Query.RequestModels
{
    public class GetMovieCountRequest : IRequest<GetMovieCountResponse>
    {
    }
}
