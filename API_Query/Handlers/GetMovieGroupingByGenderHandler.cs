using API_Query.RequestModels;
using API_Query.ResponseModels;
using Cqrs_Domain.Queries.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace API_Query.Handlers
{
    public class GetMovieGroupingByGenderHandler : IRequestHandler<GetMovieGroupingByGenderRequest, GetMovieGroupingByGenderResponse>
    {
        private IMovieQueryService _service;

        public GetMovieGroupingByGenderHandler(IMovieQueryService service)
        {
            _service = service;
        }

        public Task<GetMovieGroupingByGenderResponse> Handle(GetMovieGroupingByGenderRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new GetMovieGroupingByGenderResponse()
            {
                MoviesGroupingByGender = _service.MovieGroupingByGenders()
            });
        }
    }
}
