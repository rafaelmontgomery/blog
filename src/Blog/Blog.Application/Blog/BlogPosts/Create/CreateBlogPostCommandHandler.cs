using Blog.Domain.Entities;
using Blog.Domain.Interfaces.Repositories;
using MediatR;

namespace Blog.Application.Blog.BlogPosts.Create;
public class CreateBlogPostCommandHandler(IBlogPostRepository blogPostRepository) : IRequestHandler<CreateBlogPostCommand, CreateBlogPostResult>
{
    public async Task<CreateBlogPostResult> Handle(CreateBlogPostCommand request, CancellationToken cancellationToken)
    {
        var blogPost = BlogPost.Create(request.Title, request.Content, request.AuthorId);

        var createdBlogPost = await blogPostRepository.CreateAsync(blogPost);
        var result = new CreateBlogPostResult(createdBlogPost.Id);
        return result;
    }
}
