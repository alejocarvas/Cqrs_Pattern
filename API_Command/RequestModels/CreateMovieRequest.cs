using API_Command.ResponseModels;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace API_Command.RequestModels
{
    public class CreateMovieRequest : IRequest<CreateMovieResponse>
    {
        [Required]
        public string Title { get; set; }
        public string ReleaseDate { get; set; }
        public string Distributor { get; set; }
        public string MajorGenre { get; set; }
        public string Director { get; set; }
        public decimal Rating { get; set; }
        public int Votes { get; set; }
    }
}
