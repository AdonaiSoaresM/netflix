using Domain.Commands.AddUser;
using Domain.Commands.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] AddUserRequest request)
        {
            var response = await _mediator.Send(request);

            if (!response.Sucess)
            {
                return BadRequest(response);
            }
            else
            {
                return Ok(response);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserRequest request)
        {
            var response = await _mediator.Send(request);

            if (!response.Sucess)
            {
                return BadRequest(response);
            }
            else
            {
                return Ok(response);
            }
        }

        [Authorize]
        [HttpGet("validate")]
        public async Task<IActionResult> Validate()
        {
            return Ok(new
            {
                status = "Token Valid"
            });
        }
    }
}