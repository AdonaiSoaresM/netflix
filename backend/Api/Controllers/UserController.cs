using Domain.Commands.AddUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    public class UserController : Controller
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("add")]
        public async Task<IActionResult> Add(AddUserRequest request)
        {
            var response = await _mediator.Send(request);

            if (!response.Sucess)
            {
                return BadRequest(response);
            }
            else { return Ok(response); }
        }
    }
}