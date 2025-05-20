using Blog.Application.Blog.BlogPosts.Create;
using FluentValidation;

namespace Blog.Application.Blog.BlogPosts.Create;
public class CreateBlogPostCommandValidator : AbstractValidator<CreateBlogPostCommand>
{
    public CreateBlogPostCommandValidator()
    {
        RuleFor(user => user.Title).NotEmpty().Length(3, 100);
        RuleFor(user => user.Content).NotEmpty().Length(3, 2000);
    }
}
