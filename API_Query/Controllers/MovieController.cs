using API_Query.RequestModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace API_Query.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("query/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MovieController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all movies
        /// </summary>
        /// <returns>Movie list</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllMovieRequest());
            return Ok(response);
        }

        /// <summary>
        /// Get a movie by id
        /// </summary>
        /// <param name="id">Movie identifier</param>
        /// <returns>Movie</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetById(int id)
        {
            var response = await _mediator.Send(new GetMovieByIdRequest() { Id = id });
            return Ok(response);
        }

        /// <summary>
        /// Get a movie counter
        /// </summary>
        /// <returns>Movie</returns>
        [HttpGet("Count")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetMovieCount()
        {
            var response = await _mediator.Send(new GetMovieCountRequest());
            return Ok(response);
        }

        /// <summary>
        /// Get a movie by major genre
        /// </summary>
        /// <param name="gender">Movie major genre</param>
        /// <returns>Movie list</returns>
        [HttpGet("Gender/{gender}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetByGender(string gender)
        {
            var response = await _mediator.Send(new GetMoviesByGenderRequest() { Gender = gender });
            return Ok(response);
        }

        /// <summary>
        /// Get a movie by major genre
        /// </summary>
        /// <param name="gender">Movie major genre</param>
        /// <returns>Movie list</returns>
        [HttpGet("ToInsert")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetMoviesToInsert()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://raw.githubusercontent.com/vega/vega/master/docs/data/movies.json");
            if (response.IsSuccessStatusCode)
            {
                return Ok(await response.Content.ReadAsStringAsync());
            }
            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GroupingByGender")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetUserGroupingByAges()
        {
            var response = await _mediator.Send(new GetMovieGroupingByGenderRequest());
            return Ok(response);
        }
    }
}
