using Cqrs_DTO;
using System.Collections.Generic;

namespace API_Query.ResponseModels
{
    public class GetAllMovieResponse
    {
        public IEnumerable<Movie> Movies { get; set; }
    }
}
