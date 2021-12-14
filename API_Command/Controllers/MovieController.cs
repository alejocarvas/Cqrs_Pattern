using API_Command.RequestModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Command.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("command/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MovieController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Function to create a new movie in database
        /// </summary>
        /// <param name="requestModel">Object CreateMovieRequest with all information to create a new movie</param>
        /// <returns>CreateMovieResponse with the new movie identifier</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Post(CreateMovieRequest requestModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var response = await _mediator.Send(requestModel);
            return Ok(response);
        }

        /// <summary>
        /// Function to create a new movie in database
        /// </summary>
        /// <param name="requestModel">Object CreateMovieRequest with all information to create a new movie</param>
        /// <returns>CreateMovieResponse with the new movie identifier</returns>
        [HttpPost("{id}/User/{user}/Clicked")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> PostMovieUserClicked(int id, int user)
        {
            var response = await _mediator.Send(new CreateMovieUserClickedRequest()
            {
                MovieId = id,
                UserId = user
            });
            return Ok(response);
        }

        /// <summary>
        /// Function to delete a movie from database
        /// </summary>
        /// <param name="id">Movie identifier</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new DeleteMovieRequest() { Id = id });
            return Ok(response);
        }
    }
}
