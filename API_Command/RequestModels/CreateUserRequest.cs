using API_Command.ResponseModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
