using System.Text.RegularExpressions;
using FluentValidation;

namespace Blog.Common.Validation;
public partial class EmailValidator : AbstractValidator<string>
{
    public EmailValidator()
    {
        RuleFor(email => email)
            .NotEmpty()
            .WithMessage("The email address cannot be empty.")
            .MaximumLength(100)
            .WithMessage("The email address cannot be longer than 100 characters.")
            .Must(BeValidEmail)
            .WithMessage("The provided email address is not valid.");
    }

    private static bool BeValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        var regex = EmailRegex();
        return regex.IsMatch(email);
    }

    [GeneratedRegex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
    private static partial Regex EmailRegex();
}