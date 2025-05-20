using Blog.Application.Exceptions;
using Blog.Domain.Interfaces.Repositories;
using MediatR;

namespace Blog.Application.Blog.BlogPosts.Delete;
public class DeleteBlogPostCommandHandler(IBlogPostRepository blogPostRepository) : IRequestHandler<DeleteBlogPostCommand, DeleteBlogPostResult>
{
    public async Task<DeleteBlogPostResult> Handle(DeleteBlogPostCommand request, CancellationToken cancellationToken)
    {
        var blogPost = await blogPostRepository.GetByIdAsync(request.Id, cancellationToken) ??
                throw new BlogApplicationException("Post not found");

        var deletedBlogPost = await blogPostRepository.DeleteAsync(blogPost, cancellationToken);
        var result = new DeleteBlogPostResult(deletedBlogPost.Id);
        return result;
    }
}
