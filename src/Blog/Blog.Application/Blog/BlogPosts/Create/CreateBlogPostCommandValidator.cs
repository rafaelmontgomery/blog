using FluentValidation;

namespace Blog.Application.Blog.BlogPosts.Create;
public class CreateBlogPostCommandValidator : AbstractValidator<CreateBlogPostCommand>
{
    public CreateBlogPostCommandValidator()
    {
        RuleFor(post => post.Title).NotEmpty().Length(3, 100);
        RuleFor(post => post.Content).NotEmpty().Length(3, 2000);
    }
}
