using System;
using System.Collections.Generic;
using System.Text;

namespace Cqrs_DTO
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ReleaseDate { get; set; }
        public string Distributor { get; set; }
        public string MajorGenre { get; set; }
        public string Director { get; set; }
        public decimal Rating { get; set; }
        public int Votes { get; set; }
    }
}
