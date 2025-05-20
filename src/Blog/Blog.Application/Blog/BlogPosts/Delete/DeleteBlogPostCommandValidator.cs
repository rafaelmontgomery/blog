using FluentValidation;

namespace Blog.Application.Blog.BlogPosts.Delete;
public class DeleteBlogPostCommandValidator : AbstractValidator<DeleteBlogPostCommand>
{
    public DeleteBlogPostCommandValidator()
    {
        RuleFor(post => post.Id).NotEmpty();
    }
}
