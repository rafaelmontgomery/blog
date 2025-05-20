using MediatR;

namespace Blog.Application.Blog.BlogPosts.Create;
public sealed record CreateBlogPostCommand(string Title, string Content, Guid AuthorId) : IRequest<CreateBlogPostResult>;