using Cqrs_DTO;
using System.Collections.Generic;

namespace API_Query.ResponseModels
{
    public class GetMoviesByGenderResponse
    {
        public IEnumerable<Movie> Movies { get; set; }
    }
}
