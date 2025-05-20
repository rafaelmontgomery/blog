using Blog.Application.Exceptions;
using Blog.Domain.Interfaces.Repositories;
using MediatR;

namespace Blog.Application.Blog.BlogPosts.Update;
public class UpdateBlogPostCommandHandler(IBlogPostRepository blogPostRepository) : IRequestHandler<UpdateBlogPostCommand, UpdateBlogPostResult>
{
    public async Task<UpdateBlogPostResult> Handle(UpdateBlogPostCommand request, CancellationToken cancellationToken)
    {
        var blogPost = await blogPostRepository.GetByAuthorAndIdAsync(request.Id, request.AuthorId, cancellationToken) ??
            throw new BlogApplicationException("Post not found for this author");

        blogPost.Edit(request.Title, request.Content);
        var updatedBlogPost = await blogPostRepository.UpdateAsync(blogPost, cancellationToken);
        var result = new UpdateBlogPostResult(updatedBlogPost.Id);
        return result;
    }
}
