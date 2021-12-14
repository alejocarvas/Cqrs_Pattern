using Cqrs_DTO;
using System.Collections.Generic;

namespace API_Query.ResponseModels
{
    public class GetMovieGroupingByGenderResponse
    {
        public IEnumerable<MovieGroupingByGender> MoviesGroupingByGender { get; set; }
    }
}
