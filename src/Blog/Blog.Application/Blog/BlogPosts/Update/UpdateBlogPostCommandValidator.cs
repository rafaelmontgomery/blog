using FluentValidation;

namespace Blog.Application.Blog.BlogPosts.Update;
public class UpdateBlogPostCommandValidator : AbstractValidator<UpdateBlogPostCommand>
{
    public UpdateBlogPostCommandValidator()
    {
        RuleFor(post => post.Id).NotEmpty();
        RuleFor(post => post.Title).NotEmpty().Length(3, 100);
        RuleFor(post => post.Content).NotEmpty().Length(3, 2000);
    }
}
