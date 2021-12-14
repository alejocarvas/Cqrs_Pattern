using Cqrs_DTO;
using System.Collections.Generic;

namespace API_Query.ResponseModels
{
    public class GetAllUserResponse
    {
        public IEnumerable<User> Users { get; set; }
    }
}
