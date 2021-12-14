using API_Query.ResponseModels;
using MediatR;

namespace API_Query.RequestModels
{
    public class GetUserByIdRequest : IRequest<GetUserByIdResponse>
    {
        public int Id { get; set; }
    }
}
