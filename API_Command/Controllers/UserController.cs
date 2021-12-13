using API_Command.RequestModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        /// <summary>
        /// Function to update an user in database
        /// </summary>
        /// <param name="requestModel">Object UpdateUserRequest with all information to update the user</param>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Put(UpdateUserRequest requestModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var response = await _mediator.Send(requestModel);
            return Ok(response);
        }

        /// <summary>
        /// Update user name
        /// </summary>
        /// <param name="id">User identifier</param>
        /// <param name="name">User name</param>
        [HttpPut("{id}/Name/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> PutName(int id, string name)
        {
            var response = await _mediator.Send(new UpdateUserNameRequest() { Id = id, Name = name });
            return Ok(response);
        }

        /// <summary>
        /// Update user age
        /// </summary>
        /// <param name="id">User identifier</param>
        /// <param name="age">User age</param>
        [HttpPut("{id}/Age/{age}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> PutAge(int id, int age)
        {
            var response = await _mediator.Send(new UpdateUserAgeRequest() { Id = id, Age = age });
            return Ok(response);
        }

        /// <summary>
        /// Function to delete a user from database
        /// </summary>
        /// <param name="id">User identifier to delete</param>
        /// <returns>CreateUserResponse with the new user identifier</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new DeleteUserRequest() { Id = id });
            return Ok(response);
        }
    }
}
