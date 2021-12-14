using Cqrs_DTO;
using System.Collections.Generic;

namespace API_Query.ResponseModels
{
    public class GetUserGroupingByAgesResponse
    {
        public IEnumerable<UserGroupingByAge> UserGroupingByAges { get; set; }

    }
}
