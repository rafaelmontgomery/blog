using MediatR;

namespace Blog.Application.Blog.BlogPosts.Update;
public sealed record UpdateBlogPostCommand(Guid Id, string Title, string Content, Guid AuthorId) : IRequest<UpdateBlogPostResult>;