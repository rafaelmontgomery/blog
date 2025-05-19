using Blog.Common.Validation;
using Blog.Domain.Enums;
using FluentValidation;

namespace Blog.Application.Identity.Users.Create;
public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(user => user.Email).SetValidator(new EmailValidator());
        RuleFor(user => user.Username).NotEmpty().Length(3, 50);
        RuleFor(user => user.Password).SetValidator(new PasswordValidator());
        RuleFor(user => user.Phone).Matches(@"^\+?[1-9]\d{1,14}$");
        RuleFor(user => user.Role).NotEqual(UserRole.None);
    }
}