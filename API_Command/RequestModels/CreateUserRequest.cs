using API_Command.ResponseModels;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace API_Command.RequestModels
{
    public class CreateUserRequest : IRequest<CreateUserResponse>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
    }
}
