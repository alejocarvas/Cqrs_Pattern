using System;
using System.Collections.Generic;
using System.Text;

namespace Cqrs_DTO
{
    public class MovieClick
    {
        public int Id { get; set; }
        public int IdMovie { get; set; }
        public int IdUser { get; set; }
        public DateTime DateClick { get; set; }
    }
}
