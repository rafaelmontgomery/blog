using Blog.API.Common;
using Blog.API.Controllers.Abstractions;
using Blog.Application.Identity.Auth;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers.Identity;
public class AuthController(ISender sender) : ApiController
{
    [HttpPost]
    [AllowAnonymous]
    //[ProducesResponseType(typeof(ApiResponseWithData<AuthenticateUserResponse>), StatusCodes.Status200OK)]
    //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> AuthenticateUser([FromBody] AuthenticateUserRequest request, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var command = request.ToCommand();

        var result = await sender.Send(command, cancellationToken);

        return Ok(new ApiResponseWithData<AuthenticateUserResult>
        {
            Success = true,
            Message = "User authenticated successfully",
            Data = result
        });
    }
}
