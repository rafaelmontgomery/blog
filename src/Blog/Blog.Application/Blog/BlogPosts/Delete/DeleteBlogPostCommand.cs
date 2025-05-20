using MediatR;

namespace Blog.Application.Blog.BlogPosts.Delete;
public sealed record DeleteBlogPostCommand(Guid Id) : IRequest<DeleteBlogPostResult>;