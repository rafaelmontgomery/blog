using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Blog.API.Controllers.Abstractions;

[ApiController]
[Route("api/[controller]")]
//[Authorize]
[ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
[ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
[ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
public abstract class ApiController : ControllerBase;