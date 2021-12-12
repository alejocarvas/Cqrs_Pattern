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
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Function to create a new user in database
        /// </summary>
        /// <param name="requestModel">Object CreateUserRequest with all information to create a new user</param>
        /// <returns>CreateUserResponse with the new user identifier</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Post(CreateUserRequest requestModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var response = await _mediator.Send(requestModel);
            return Ok(response);
        }
    }
}
