using API_Query.ResponseModels;
using MediatR;

namespace API_Query.RequestModels
{
    public class GetMoviesByGenderRequest : IRequest<GetMoviesByGenderResponse>
    {
        public string Gender { get; set; }
    }
}
