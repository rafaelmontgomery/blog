using Blog.API.Common;
using Blog.API.Controllers.Abstractions;
using Blog.Application.Blog.BlogPosts.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers.Blog;
public class BlogPostsController(ISender sender) : ApiController
{
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateBlogPostRequest>), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] CreateBlogPostRequest request, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var userId = GetUserId();

        if (userId == Guid.Empty)
            return BadRequest("User id not found");


        var command = request.ToCommand(userId);

        var result = await sender.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<CreateBlogPostResult>
        {
            Success = true,
            Message = "Blog post created successfully",
            Data = result
        });
    }
}
