using Blog.API.Controllers.Abstractions;
using Blog.Application.Identity.Users.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers.Identity;
public class UsersController(ISender sender) : ApiController
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var command = request.ToCommand();

        var result = await sender.Send(command, cancellationToken);

        return Created(string.Empty, result);
    }
}
