using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Command.RequestModels
{
    public class DeleteMovieRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
